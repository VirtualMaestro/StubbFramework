using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Common.Names;
using StubbFramework.Logging;
using StubbFramework.Physics;
using StubbFramework.Physics.Components;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;
using StubbFramework.Scenes.Services;

namespace StubbFramework.Extensions
{
    public static class WorldExtension
    {
        private static readonly Dictionary<int, bool> CollisionTable = new Dictionary<int, bool>();
        private static readonly Dictionary<int, bool> RegisterCollisionTable = new Dictionary<int, bool>();

        /// <summary>
        /// Add configuration of the scenes list to load.
        /// LoadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"> Extension to the EcsWorld</param>
        /// <param name="configs">List of the ILoadingSceneConfig to load</param>
        public static void LoadScenes(this EcsWorld world, List<ILoadingSceneConfig> configs)
        {
            world.NewEntityWith<LoadScenesComponent>(out var loadScenes);
            loadScenes.LoadingScenes = configs;
            loadScenes.UnloadingScenes = null;
            loadScenes.UnloadOthers = false;
        }
        
        /// <summary>
        /// Add configuration of the scenes list to load.
        /// LoadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"> Extension to the EcsWorld</param>
        /// <param name="configs">List of the ILoadingSceneConfig to load</param>
        /// <param name="unloadScenes">scenes names which have to unload after given list config of new scenes will be loaded.</param>
        public static void LoadScenes(this EcsWorld world, List<ILoadingSceneConfig> configs, List<IAssetName> unloadScenes) 
        {
            world.NewEntityWith<LoadScenesComponent>(out var loadScenes);
            loadScenes.LoadingScenes = configs;
            loadScenes.UnloadingScenes = unloadScenes;
            loadScenes.UnloadOthers = false;
        }

        /// <summary>
        /// Add configuration of the scenes list to load.
        /// LoadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"> Extension to the EcsWorld</param>
        /// <param name="configs">List of the ILoadingSceneConfig to load</param>
        /// <param name="unloadOthers">if true all current non new scenes will be unloaded</param>
        public static void LoadScenes(this EcsWorld world, List<ILoadingSceneConfig> configs, bool unloadOthers)
        {
            world.NewEntityWith<LoadScenesComponent>(out var loadScenes);
            loadScenes.LoadingScenes = configs;
            loadScenes.UnloadingScenes = null;
            loadScenes.UnloadOthers = unloadOthers;
        }

        /// <summary>
        /// Unload list of scenes.
        /// Names of scenes should be specified in full name format (path+name).
        /// UnloadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="unloadScenes"></param>
        public static void UnloadScenes(this EcsWorld world, List<IAssetName> unloadScenes)
        {
            world.NewEntityWith<UnloadScenesComponent>(out var unloadScenesComponent);
            unloadScenesComponent.SceneNames = unloadScenes;
        }

        /// <summary>
        /// Removes all current scenes.
        /// </summary>
        /// <param name="world"></param>
        public static void UnloadAllScenes(this EcsWorld world)
        {
            world.NewEntityWith<UnloadScenesComponent>(out var unloadScenesComponent);
        }

        /// <summary>
        /// Remove all scenes which don't mark with NewSceneMarkerComponent.
        /// </summary>
        /// <param name="world"></param>
        public static void UnloadNonNewScenes(this EcsWorld world)
        {
            world.NewEntityWith<UnloadNonNewScenesComponent>(out var unloadNonNewScenesComponent);
        }

        public static void AddSceneService(this EcsWorld world, ISceneService sceneService)
        {
            world.NewEntityWith<SceneServiceComponent>(out var sceneServiceComponent);
            sceneServiceComponent.SceneService = sceneService;
        }

        public static void ActivateScene(this EcsWorld world, IAssetName sceneName, bool isMain = false)
        {
            _ActivationScene(world, sceneName, true, isMain);
        }

        public static void DeactivateScene(this EcsWorld world, IAssetName sceneName, bool isMain = false)
        {
            _ActivationScene(world, sceneName, false, isMain);
        }

        public static void DispatchTriggerEnter(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
            
            RegisterCollision(ref objA, ref objB, in result, in hash);
            
            world.NewEntityWith<TriggerEnterComponent, CleanupCollisionComponent>(out var triggerEnter, out var cleanup);
            triggerEnter.ObjectA = objA;
            triggerEnter.ObjectB = objB;
            triggerEnter.Info = collisionInfo;
        }

        public static void DispatchTriggerEnter2D(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
            
            RegisterCollision(ref objA, ref objB, in result, in hash);
            
            world.NewEntityWith<TriggerEnter2DComponent, CleanupCollisionComponent>(out var triggerEnter, out var cleanup);
            triggerEnter.ObjectA = objA;
            triggerEnter.ObjectB = objB;
            triggerEnter.Info = collisionInfo;
        }

        public static void DispatchTriggerStay(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
            
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<TriggerStayComponent, CleanupCollisionComponent>(out var triggerStay, out var cleanup);
            triggerStay.ObjectA = objA;
            triggerStay.ObjectB = objB;
            triggerStay.Info = collisionInfo;
        }

        public static void DispatchTriggerStay2D(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
            
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<TriggerStay2DComponent, CleanupCollisionComponent>(out var triggerStay, out var cleanup);
            triggerStay.ObjectA = objA;
            triggerStay.ObjectB = objB;
            triggerStay.Info = collisionInfo;
        }

        public static void DispatchTriggerExit(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
           
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<TriggerExitComponent, CleanupCollisionComponent>(out var triggerExit, out var cleanup);
            triggerExit.ObjectA = objA;
            triggerExit.ObjectB = objB;
            triggerExit.Info = collisionInfo;
        }

        public static void DispatchTriggerExit2D(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
           
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<TriggerExit2DComponent, CleanupCollisionComponent>(out var triggerExit, out var cleanup);
            triggerExit.ObjectA = objA;
            triggerExit.ObjectB = objB;
            triggerExit.Info = collisionInfo;
        }

        public static void DispatchCollisionEnter(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
           
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<CollisionEnterComponent, CleanupCollisionComponent>(out var collisionEnter, out var cleanup);
            collisionEnter.ObjectA = objA;
            collisionEnter.ObjectB = objB;
            collisionEnter.Info = collisionInfo;
        }
        
        public static void DispatchCollisionEnter2D(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
           
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<CollisionEnter2DComponent, CleanupCollisionComponent>(out var collisionEnter, out var cleanup);
            collisionEnter.ObjectA = objA;
            collisionEnter.ObjectB = objB;
            collisionEnter.Info = collisionInfo;
        }
        
        public static void DispatchCollisionStay(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
          
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<CollisionStayComponent, CleanupCollisionComponent>(out var collisionStay, out var cleanup);
            collisionStay.ObjectA = objA;
            collisionStay.ObjectB = objB;
            collisionStay.Info = collisionInfo;
        }
        
        public static void DispatchCollisionStay2D(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
          
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<CollisionStay2DComponent, CleanupCollisionComponent>(out var collisionStay, out var cleanup);
            collisionStay.ObjectA = objA;
            collisionStay.ObjectB = objB;
            collisionStay.Info = collisionInfo;
        }
        
        public static void DispatchCollisionExit(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
            
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<CollisionExitComponent, CleanupCollisionComponent>(out var collisionExit, out var cleanup);
            collisionExit.ObjectA = objA;
            collisionExit.ObjectB = objB;
            collisionExit.Info = collisionInfo;
        }

        public static void DispatchCollisionExit2D(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            if (CanDispatch(objA.TypeId, objB.TypeId, out int result, out int hash) == false) return;
            
            RegisterCollision(ref objA, ref objB, in result, in hash);

            world.NewEntityWith<CollisionExit2DComponent, CleanupCollisionComponent>(out var collisionExit, out var cleanup);
            collisionExit.ObjectA = objA;
            collisionExit.ObjectB = objB;
            collisionExit.Info = collisionInfo;
        }

        /// <summary>
        /// Add two uniques ids (ints) as collision pair.
        /// Ids should be > 0.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="typeIdA"></param>
        /// <param name="typeIdB"></param>
        /// <param name="shift"></param>
        public static void AddCollisionPair(this EcsWorld world, int typeIdA, int typeIdB, int shift = 8)
        {
            _VerifyCollisionPair(world, typeIdA, typeIdB, shift);
            
            CollisionTable[_GetHash(typeIdA, typeIdB, shift)] = true;
        }

        /// <summary>
        /// Check if given collision pair exist.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="typeIdA"></param>
        /// <param name="typeIdB"></param>
        /// <param name="shift"></param>
        /// <returns>
        /// -1 - no collision pair;
        ///  0 - collision pair exists in given order;
        ///  1 - collision pair exists in reverse order;
        /// </returns>
        public static int HasCollisionPair(this EcsWorld world, int typeIdA, int typeIdB, int shift = 8)
        {
            if (typeIdA <= 0 || typeIdB <= 0) return -1; 
            if (CollisionTable.ContainsKey(_GetHash(typeIdA, typeIdB, shift))) return 0;
            if (CollisionTable.ContainsKey(_GetHash(typeIdB, typeIdA, shift))) return 1;
            
            return -1;
        }
        
        public static void EndPhysicsFrame(this EcsWorld world)
        {
            RegisterCollisionTable.Clear();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RegisterCollision(ref IViewPhysics objA, ref IViewPhysics objB, in int result, in int hash)
        {
            if (result == 1)
            {
                var tmp = objA;
                objA = objB;
                objB = tmp;
            }

            RegisterCollisionTable[hash] = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool CanDispatch(int typeIdA, int typeIdB, out int result, out int hashResult, int shift = 8)
        {
            result = -1;
            hashResult = -1;
            
            if (typeIdA <= 0 || typeIdB <= 0) return false;

            int hash = _GetHash(typeIdA, typeIdB, shift);
            if (CollisionTable.ContainsKey(hash))
            {
                result = 0;
                hashResult = hash;
                return RegisterCollisionTable.ContainsKey(hash) == false;
            }
            
            int reverseHash = _GetHash(typeIdB, typeIdA, shift);
            if (CollisionTable.ContainsKey(reverseHash))
            {
                result = 1;
                hashResult = reverseHash;
                return RegisterCollisionTable.ContainsKey(reverseHash) == false;
            }

            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int _GetHash(int byte1, int byte2, int shift)
        {
            return byte1 | byte2 << shift;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void _ActivationScene(EcsWorld world, IAssetName sceneName, bool enable, bool isMain)
        {
            world.NewEntityWith<ActivateSceneComponent>(out var activateSceneComponent);
            activateSceneComponent.Name = sceneName;
            activateSceneComponent.Active = enable;
            activateSceneComponent.IsMain = isMain;
        }
        
        [Conditional("DEBUG")]
        private static void _VerifyCollisionPair(EcsWorld world, int typeIdA, int typeIdB, int shift)
        {
            if (typeIdA <= 0 || typeIdB <= 0)
            {
                log.Error($"Wrong collision pair: {typeIdA}:{typeIdB} - collision type should be > 0.");
            } 

            if (HasCollisionPair(world, typeIdA, typeIdB, shift) >= 0)
            {
                log.Warn($"Collision pair {typeIdA} : {typeIdB} is already added!");
            }
        }
    }
}
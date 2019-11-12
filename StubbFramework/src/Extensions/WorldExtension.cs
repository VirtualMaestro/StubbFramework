﻿using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Common.Names;
using StubbFramework.Physics;
using StubbFramework.Physics.Components;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;
using StubbFramework.Services;
using StubbFramework.Services.Components;

namespace StubbFramework.Extensions
{
    public static class WorldExtension
    {
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

        public static void DispatchTriggerEnter(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            world.NewEntityWith<TriggerEnterComponent>(out var triggerEnter);
            triggerEnter.ObjectA = objA;
            triggerEnter.ObjectB = objB;
            triggerEnter.Info = collisionInfo;
        }

        public static void DispatchTriggerStay(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            world.NewEntityWith<TriggerStayComponent>(out var triggerStay);
            triggerStay.ObjectA = objA;
            triggerStay.ObjectB = objB;
            triggerStay.Info = collisionInfo;
        }

        public static void DispatchTriggerExit(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            world.NewEntityWith<TriggerExitComponent>(out var triggerExit);
            triggerExit.ObjectA = objA;
            triggerExit.ObjectB = objB;
            triggerExit.Info = collisionInfo;
        }

        public static void DispatchCollisionEnter(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            world.NewEntityWith<CollisionEnterComponent>(out var collisionEnter);
            collisionEnter.ObjectA = objA;
            collisionEnter.ObjectB = objB;
            collisionEnter.Info = collisionInfo;
        }
        
        public static void DispatchCollisionStay(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            world.NewEntityWith<CollisionStayComponent>(out var collisionStay);
            collisionStay.ObjectA = objA;
            collisionStay.ObjectB = objB;
            collisionStay.Info = collisionInfo;
        }
        
        public static void DispatchCollisionExit(this EcsWorld world, IViewPhysics objA, IViewPhysics objB, object collisionInfo)
        {
            world.NewEntityWith<CollisionExitComponent>(out var collisionExit);
            collisionExit.ObjectA = objA;
            collisionExit.ObjectB = objB;
            collisionExit.Info = collisionInfo;
        }
    }
}
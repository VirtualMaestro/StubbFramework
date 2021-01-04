using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Common.Names;
using StubbFramework.Remove.Components;
using StubbFramework.Scenes;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;
using StubbFramework.Scenes.Events;
using StubbFramework.Scenes.Services;

namespace StubbFramework.Extensions
{
    public static class SceneWorldExtension
    {
        public static void AddSceneService(this EcsWorld world, ISceneService sceneService)
        {
            world.NewEntity().Get<SceneServiceComponent>().SceneService = sceneService;
        }

        /// <summary>
        /// Loads a scene by a config.  
        /// </summary>
        public static void LoadScene(this EcsWorld world, ILoadingSceneConfig config)
        {
            var list = new List<ILoadingSceneConfig> {config};
            LoadScenes(world, list);
        }
        
        /// <summary>
        /// Loads a scene by a config and unload scene with a given name.  
        /// </summary>
        public static void LoadScene(this EcsWorld world, ILoadingSceneConfig config, IAssetName unloadScene)
        {
            var loadList = new List<ILoadingSceneConfig> {config};
            var unloadList = new List<IAssetName> {unloadScene};
            LoadScenes(world, loadList, unloadList);
        }
        
        /// <summary>
        /// Loads a scene by a config and unload scene with a given names.  
        /// </summary>
        public static void LoadScene(this EcsWorld world, ILoadingSceneConfig config, List<IAssetName> unloadScenes)
        {
            var list = new List<ILoadingSceneConfig> {config};
            LoadScenes(world, list, unloadScenes);
        }
        
        /// <summary>
        /// Loads a scene by a config and unload others scenes.  
        /// </summary>
        public static void LoadScene(this EcsWorld world, ILoadingSceneConfig config, bool unloadOthers)
        {
            var list = new List<ILoadingSceneConfig> {config};
            LoadScenes(world, list, unloadOthers);
        }
        
        /// <summary>
        /// Add configuration of the scenes list to load.
        /// LoadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"> Extension to the EcsWorld</param>
        /// <param name="configs">List of the ILoadingSceneConfig to load</param>
        public static void LoadScenes(this EcsWorld world, List<ILoadingSceneConfig> configs)
        {
            ref var loadScenes = ref world.NewEntity().Get<LoadScenesEvent>();
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
            ref var loadScenes = ref world.NewEntity().Get<LoadScenesEvent>();
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
            ref var loadScenes = ref world.NewEntity().Get<LoadScenesEvent>();
            loadScenes.LoadingScenes = configs;
            loadScenes.UnloadingScenes = null;
            loadScenes.UnloadOthers = unloadOthers;
        }

        /// <summary>
        /// Unload scene by the given name.
        /// </summary>
        public static void UnloadScene(this EcsWorld world, IAssetName sceneName)
        {
            var list = new List<IAssetName> {sceneName};
            UnloadScenes(world, list);
        }

        /// <summary>
        /// Unload a scene by given ISceneController.
        /// Throws exception in DEBUG mode if scene is in the unloading process or was already removed.
        /// </summary>
        public static void UnloadScene(this EcsWorld world, ISceneController controller)
        {
            ref var entity = ref controller.GetEntity();
#if DEBUG            
            if (controller.IsDisposed || entity.Has<SceneUnloadingComponent>() || entity.Has<RemoveEntityComponent>())
                throw new System.Exception($"Try to unload scene with name '{controller.SceneName}' which is already in unloading process or was unloaded!");
#endif
            entity.Get<RemoveEntityComponent>();
        }

        /// <summary>
        /// Unload list of scenes.
        /// Names of scenes should be specified in full name format (path+name).
        /// UnloadScenesComponent will be sent.
        /// </summary>
        public static void UnloadScenes(this EcsWorld world, List<IAssetName> sceneNames)
        {
            ref var scenes = ref world.NewEntity().Get<UnloadScenesByNamesEvent>();
            scenes.SceneNames = sceneNames;
        }

        /// <summary>
        /// Removes all current scenes.
        /// </summary>
        public static void UnloadAllScenes(this EcsWorld world)
        {
            world.NewEntity().Get<UnloadAllScenesEvent>();
        }

        /// <summary>
        /// Remove all scenes which wasn't mark as new (with NewSceneMarkerComponent).
        /// </summary>
        /// <param name="world"></param>
        public static void UnloadNonNewScenes(this EcsWorld world)
        {
            world.NewEntity().Get<UnloadNonNewScenesEvent>();
        }

        /// <summary>
        /// Activate scene by its name.
        /// </summary>
        public static void ActivateScene(this EcsWorld world, IAssetName sceneName, bool isMain = false)
        {
            ref var activateScene = ref world.NewEntity().Get<ActivateSceneByNameEvent>();
            activateScene.Name = sceneName;
            activateScene.IsMain = isMain;
        }

        /// <summary>
        /// Activate scene by its ISceneController.
        /// </summary>
        public static void ActivateScene(this EcsWorld world, ISceneController controller, bool isMain = false)
        {
            ref var entity = ref controller.GetEntity();
#if DEBUG            
            if (entity.Has<IsSceneActiveComponent>())
                throw new System.Exception($"Try to activate scene with name '{controller.SceneName}' which is already activated!");
#endif
            ref var activateScene = ref entity.Get<ActivateSceneComponent>();
            activateScene.IsMain = isMain;
        }

        /// <summary>
        /// Deactivate a scene by its name.
        /// </summary>
        public static void DeactivateScene(this EcsWorld world, IAssetName sceneName)
        {
            world.NewEntity().Get<DeactivateSceneByNameEvent>().Name = sceneName;
        }

        /// <summary>
        /// Deactivate a scene by its controller.
        /// </summary>
        public static void DeactivateScene(this EcsWorld world, ISceneController controller)
        {
#if DEBUG            
            if (controller.GetEntity().Has<IsSceneInactiveComponent>())
                throw new System.Exception($"Try to deactivate scene with name '{controller.SceneName}' which is already deactivated!");
#endif
            controller.GetEntity().Get<DeactivateSceneComponent>();
        }
    }
}
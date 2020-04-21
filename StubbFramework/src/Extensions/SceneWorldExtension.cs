using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Common.Names;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;
using StubbFramework.Scenes.Services;

namespace StubbFramework.Extensions
{
    public static class SceneWorldExtension
    {
        /// <summary>
        /// Add configuration of the scenes list to load.
        /// LoadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"> Extension to the EcsWorld</param>
        /// <param name="configs">List of the ILoadingSceneConfig to load</param>
        public static void LoadScenes(this EcsWorld world, List<ILoadingSceneConfig> configs)
        {
            ref var loadScenes = ref world.NewEntity().Set<LoadScenesEvent>();
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
        public static void LoadScenes(this EcsWorld world, List<ILoadingSceneConfig> configs,
            List<IAssetName> unloadScenes)
        {
            ref var loadScenes = ref world.NewEntity().Set<LoadScenesEvent>();
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
            ref var loadScenes = ref world.NewEntity().Set<LoadScenesEvent>();
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
            ref var scenes = ref world.NewEntity().Set<UnloadScenesByNamesEvent>();
            scenes.SceneNames = unloadScenes;
        }

        /// <summary>
        /// Removes all current scenes.
        /// </summary>
        /// <param name="world"></param>
        public static void UnloadAllScenes(this EcsWorld world)
        {
            world.NewEntity().Set<UnloadAllScenesEvent>();
        }

        /// <summary>
        /// Remove all scenes which don't mark with NewSceneMarkerComponent.
        /// </summary>
        /// <param name="world"></param>
        public static void UnloadNonNewScenes(this EcsWorld world)
        {
            world.NewEntity().Set<UnloadNonNewScenesEvent>();
        }

        public static void AddSceneService(this EcsWorld world, ISceneService sceneService)
        {
            world.NewEntity().Set<SceneServiceComponent>().SceneService = sceneService;
        }

        public static void ActivateScene(this EcsWorld world, IAssetName sceneName, bool isMain = false)
        {
            ref var activateScene = ref world.NewEntity().Set<ActivateSceneByNameEvent>();
            activateScene.Name = sceneName;
            activateScene.IsMain = isMain;
        }

        public static void DeactivateScene(this EcsWorld world, IAssetName sceneName)
        {
            world.NewEntity().Set<DeactivateSceneByNameEvent>().Name = sceneName;
        }
    }
}
﻿using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Scenes;
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
        /// <param name="config">Config of scenes to load</param>
        /// <param name="unloadScenes">scenes names which have to unload after given list config of new scenes will be loaded.</param>
        public static void LoadScenes(this EcsWorld world, ILoadingScenesConfig config, IList<ISceneName> unloadScenes = null)
        {
            world.NewEntityWith<LoadScenesComponent>(out var loadScenes);
            loadScenes.LoadingScenes = config;
            loadScenes.UnloadingScenes = unloadScenes;
            loadScenes.UnloadAllOtherScenes = false;
        }

        /// <summary>
        /// Add configuration of the scenes list to load.
        /// LoadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"> Extension to the EcsWorld</param>
        /// <param name="config">Config of scenes to load</param>
        /// <param name="unloadAllOtherScenes">if true all current non new scenes will be unloaded</param>
        public static void LoadScenes(this EcsWorld world, ILoadingScenesConfig config, bool unloadAllOtherScenes = false)
        {
            world.NewEntityWith<LoadScenesComponent>(out var loadScenes);
            loadScenes.LoadingScenes = config;
            loadScenes.UnloadingScenes = null;
            loadScenes.UnloadAllOtherScenes = unloadAllOtherScenes;
        }

        /// <summary>
        /// Unload list of scenes.
        /// Names of scenes should be specified in full name format (path+name).
        /// UnloadScenesComponent will be sent.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="unloadScenes"></param>
        public static void UnloadScenes(this EcsWorld world, IList<ISceneName> unloadScenes)
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
    }
}
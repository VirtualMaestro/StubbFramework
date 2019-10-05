using Leopotam.Ecs;
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
        /// </summary>
        /// <param name="world"> Extension to the EcsWorld</param>
        /// <param name="config">Config of scenes to load</param>
        /// <param name="unloadScenes">scenes names which have to unload after given list config of new scenes will be loaded.</param>
        public static void LoadScenes(this EcsWorld world, ILoadingScenesConfig config, string[] unloadScenes = null)
        {
            world.NewEntityWith<LoadScenesComponent, InternalNewSceneListComponent>(out var loadScenes, out var newEntity);
            loadScenes.Config = config;
            loadScenes.UnloadScenes = unloadScenes;
        }

        public static void AddSceneService(this EcsWorld world, ISceneService sceneService)
        {
            world.NewEntityWith<SceneServiceComponent>(out var sceneServiceComponent);
            sceneServiceComponent.SceneService = sceneService;
        }
    }
}
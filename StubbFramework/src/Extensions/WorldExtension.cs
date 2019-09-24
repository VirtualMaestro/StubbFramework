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
        /// <param name="scenes">ISceneLoadingListConfig - list of the scenes configs</param>
        /// <param name="unloadScenes">scenes names which have to unload after given list config of new scenes will be loaded.</param>
        public static void LoadScenesComponent(this EcsWorld world, ISceneLoadingListConfig scenes, string[] unloadScenes = null)
        {
            world.CreateEntityWith<LoadScenesComponent, InternalNewSceneListComponent>(out var loadScenes,
                out var newEntity);
            loadScenes.Scenes = scenes;
            loadScenes.UnloadScenes = unloadScenes;
        }

        public static void AddSceneService(this EcsWorld world, ISceneService sceneService)
        {
            world.CreateEntityWith<SceneServiceComponent>(out var sceneServiceComponent);
            sceneServiceComponent.SceneService = sceneService;
        }
    }
}
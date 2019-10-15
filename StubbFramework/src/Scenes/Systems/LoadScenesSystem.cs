using Leopotam.Ecs;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public sealed class LoadScenesSystem : EcsSystem
    {
        EcsFilter<LoadScenesComponent> _loadScenesFilter;
        EcsFilter<SceneServiceComponent> _sceneServiceFilter;
       
        public override void Run()
        {
            if (_loadScenesFilter.IsEmpty()) return;
            var sceneService = _sceneServiceFilter.Get1[0].SceneService;
            
            foreach (var idx in _loadScenesFilter)
            {
                ref var entity = ref _loadScenesFilter.Entities[idx];
                var loadScenes = entity.Get<LoadScenesComponent>();
                ISceneLoadingProgress[] progresses = sceneService.Load(loadScenes.LoadingScenes);
                
                World.NewEntityWith<ActiveLoadingScenesComponent>(out var activeLoadingScenes);
                activeLoadingScenes.IsActivatingAll = loadScenes.LoadingScenes.IsActivatingAll;
                activeLoadingScenes.Progresses = progresses;
                activeLoadingScenes.UnloadScenes = loadScenes.UnloadingScenes;
                activeLoadingScenes.UnloadAllOtherScenes = loadScenes.UnloadAllOtherScenes;
                
                entity.Destroy();
            }
        }
    }
}
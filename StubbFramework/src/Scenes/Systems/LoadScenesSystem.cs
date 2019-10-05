using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public class LoadScenesSystem : EcsSystem
    {
        EcsFilter<LoadScenesComponent, InternalNewSceneListComponent> _newScenesFilter;
        EcsFilter<LoadScenesComponent>.Exclude<InternalNewSceneListComponent> _loadScenesFilter;
        EcsFilter<SceneServiceComponent> _sceneServiceFilter;
        EcsFilter<InternalActiveLoadingScenesComponent> _activeLoadingFilter;
       
        public override void Run()
        {
            _ProceedNewScenes();
            _LoadScenes();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _ProceedNewScenes()
        {
            foreach (var idx in _newScenesFilter)
            {
                ref var entity = ref _newScenesFilter.Entities[idx];
                entity.Unset<InternalNewSceneListComponent>();
                
                var loadScenes = entity.Get<LoadScenesComponent>();
                loadScenes.Config = loadScenes.Config.Clone();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _LoadScenes()
        {
            if (_activeLoadingFilter.IsEmpty())
            {
                foreach (var idx in _loadScenesFilter)
                {
                    var loadScene = _loadScenesFilter.Get1[idx];
                    if (loadScene.Config.IsEmpty)
                    {
                        _loadScenesFilter.Entities[idx].Destroy();
                        continue;
                    }

                    World.NewEntityWith<InternalActiveLoadingScenesComponent>(out var loadingComponent);
                    loadingComponent.Config = loadScene.Config;
                   
                    _LoadScene(loadScene.Config);

                    break;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _LoadScene(ILoadingScenesConfig configList)
        {
            var sceneService = _sceneServiceFilter.Get1[0].SceneService;
            
            foreach (var config in configList)
            {
                sceneService.Load(config);
            }
        }
    }
}
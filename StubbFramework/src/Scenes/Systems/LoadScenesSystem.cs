using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Remove;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public class LoadScenesSystem : EcsSystem
    {
        private EcsFilter<LoadScenesComponent, InternalNewSceneListComponent> _newScenesFilter;
        private EcsFilter<LoadScenesComponent>.Exclude<InternalNewSceneListComponent> _loadScenesFilter;
        private EcsFilter<SceneServiceComponent> _sceneServiceFilter;
        private EcsFilter<InternalActiveLoadingScenesComponent> _activeLoadingFilter;
       
        public override void Initialize()
        {
            _newScenesFilter = World.GetFilter<EcsFilter<LoadScenesComponent, InternalNewSceneListComponent>>();
            _loadScenesFilter = World.GetFilter<EcsFilter<LoadScenesComponent>.Exclude<InternalNewSceneListComponent>>();
            _sceneServiceFilter = World.GetFilter<EcsFilter<SceneServiceComponent>>();
            _activeLoadingFilter = World.GetFilter<EcsFilter<InternalActiveLoadingScenesComponent>>();
        }

        public override void Run()
        {
            _ProceedNewScenes();
            _LoadScenes();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _LoadScenes()
        {
            if (_activeLoadingFilter.IsEmpty())
            {
                foreach (var idx in _loadScenesFilter)
                {
                    var loadScene = _loadScenesFilter.Components1[idx];
                    if (loadScene.Config.IsEmpty)
                    {
                        World.AddComponent<RemoveEntityComponent>(_loadScenesFilter.Entities[idx]);
                        continue;
                    }
                    
                    World.CreateEntityWith<InternalActiveLoadingScenesComponent>(out var loadingComponent);
                    loadingComponent.Config = loadScene.Config;
                   
                    _LoadScene(loadScene.Config);

                    break;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _LoadScene(ISceneLoadingListConfig configList)
        {
            var sceneService = _sceneServiceFilter.Components1[0].SceneService;
            
            foreach (var config in configList)
            {
                sceneService.Load(config);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _ProceedNewScenes()
        {
            foreach (var idx in _newScenesFilter)
            {
                ref var entity = ref _newScenesFilter.Entities[idx];
                World.RemoveComponent<InternalNewSceneListComponent>(entity);
                
                var loadScenes = _newScenesFilter.Components1[idx];
                loadScenes.Config = loadScenes.Config.Clone();
            }
        }

        public override void Destroy()
        {
            _newScenesFilter = null;
            _loadScenesFilter = null;
            _sceneServiceFilter = null;
            _activeLoadingFilter = null;
        }
    }
}
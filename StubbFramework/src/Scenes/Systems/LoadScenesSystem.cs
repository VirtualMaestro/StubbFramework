using System.Runtime.CompilerServices;
using Leopotam.Ecs;
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
       
        public override void Initialize()
        {
            _newScenesFilter = World.GetFilter<EcsFilter<LoadScenesComponent, InternalNewSceneListComponent>>();
            _loadScenesFilter = World.GetFilter<EcsFilter<LoadScenesComponent>.Exclude<InternalNewSceneListComponent>>();
            _sceneServiceFilter = World.GetFilter<EcsFilter<SceneServiceComponent>>();
        }

        public override void Run()
        {
            _ProceedNewScenes();
            _LoadScenes();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _LoadScenes()
        {
            foreach (var idx in _loadScenesFilter)
            {
                var loadScene = _loadScenesFilter.Components1[idx];
                _LoadScene(loadScene.Scenes);

                break;
            }
        }

        private void _LoadScene(ISceneLoadingListConfig configs)
        {
            // todo:
//            configs.
//            _sceneServiceFilter.Components1[0].SceneService.Load(loadScene.Scenes);
            
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _ProceedNewScenes()
        {
            foreach (var idx in _newScenesFilter)
            {
                var entity = _newScenesFilter.Entities[idx];
                World.RemoveComponent<InternalNewSceneListComponent>(entity);
                var loadScenes = _newScenesFilter.Components1[idx];
                loadScenes.Scenes = loadScenes.Scenes.Clone();
            }
        }

        public override void Destroy()
        {
            _newScenesFilter = null;
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Remove.Components;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class LoadScenesSystem : IEcsRunSystem
    {
        private EcsWorld World;
        private EcsFilter<LoadScenesEvent> _loadScenesFilter;
        private EcsFilter<SceneServiceComponent> _sceneServiceFilter;

        public void Run()
        {
            if (_loadScenesFilter.IsEmpty()) return;
            var sceneService = _sceneServiceFilter.Single().SceneService;

            foreach (var idx in _loadScenesFilter)
            {
                ref var loadScenes = ref _loadScenesFilter.Get1(idx);
                ref var activeLoadingScenes = ref World.NewEntity().Set<ActiveLoadingScenesComponent>();
                activeLoadingScenes.Progresses = sceneService.Load(loadScenes.LoadingScenes);
                activeLoadingScenes.UnloadScenes = loadScenes.UnloadingScenes;
                activeLoadingScenes.UnloadOthers = loadScenes.UnloadOthers;

                ref var entity = ref _loadScenesFilter.GetEntity(idx);
                entity.Set<RemoveEntityComponent>();
            }
        }
    }
}
using System.Runtime.CompilerServices;
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
    public sealed class UnloadSceneSystem : IEcsRunSystem
    {
        private EcsFilter<SceneComponent, SceneUnloadingComponent> _unloadingScenesFilter;
        private EcsFilter<SceneComponent, RemoveEntityComponent>.Exclude<SceneUnloadingComponent> _unloadScenesFilter;
        private EcsFilter<SceneServiceComponent> _serviceFilter;
        private EcsWorld _world;

        public void Run()
        {
            _MarkRemoved();
            _MarkUnloaded();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _MarkRemoved()
        {
            if (_unloadingScenesFilter.IsEmpty()) return;
            var service = _serviceFilter.Single().SceneService;

            foreach (var idx in _unloadingScenesFilter)
            {
                _unloadingScenesFilter.GetEntity(idx).Get<RemoveEntityComponent>();

                var controller = _unloadingScenesFilter.Get1(idx).Scene;
                service.Unload(controller);
                controller.Dispose();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _MarkUnloaded()
        {
            if (_unloadScenesFilter.IsEmpty()) return;

            foreach (var idx in _unloadScenesFilter)
            {
                ref var entity = ref _unloadScenesFilter.GetEntity(idx);
                entity.Del<RemoveEntityComponent>();
                entity.Get<SceneUnloadingComponent>();
                entity.Get<DeactivateSceneComponent>();
            }
        }
    }
}
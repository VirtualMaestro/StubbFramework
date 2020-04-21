using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Common.Components;
using StubbFramework.Common.Names;
using StubbFramework.Logging;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class ChangeSceneStateByNameSystem : IEcsRunSystem
    {
        private EcsFilter<ActivateSceneByNameEvent> _activateFilter;
        private EcsFilter<DeactivateSceneByNameEvent> _deactivateFilter;
        private EcsFilter<SceneComponent> _scenesFilter;

        public void Run()
        {
            _ActivateScene();
            _DeactivateScene();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _ActivateScene()
        {
            foreach (var idx in _activateFilter)
            {
                var eventComponent = _activateFilter.Get1(idx);
                ref var entity = ref _GetSceneEntity(eventComponent.Name);

                if (entity.Has<IsActiveComponent>())
                {
                    log.Warn(
                        $"Try to perform activation for the scene {eventComponent.Name}, " +
                        $"but state of the scene is already activated!");
                    continue;
                }

                entity.Set<ActivateSceneEvent>().IsMain = eventComponent.IsMain;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _DeactivateScene()
        {
            foreach (var idx in _deactivateFilter)
            {
                var eventComponent = _deactivateFilter.Get1(idx);
                ref var entity = ref _GetSceneEntity(eventComponent.Name);

                if (entity.Has<IsInactiveComponent>())
                {
                    log.Warn(
                        $"Try to perform deactivation for the scene {eventComponent.Name}, " +
                        $"but state of the scene is already deactivated!");
                    continue;
                }

                entity.Set<DeactivateSceneEvent>();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref EcsEntity _GetSceneEntity(IAssetName sceneName)
        {
            foreach (var idx in _scenesFilter)
            {
                var scene = _scenesFilter.Get1(idx).Scene;

                if (scene.SceneName.Equals(sceneName))
                {
                    return ref scene.GetEntity();
                }
            }

            throw new InstanceNotFoundException($"Scene with name'{sceneName}' not found!");
        }
    }
}
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Common.Components;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Events;

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

        private EcsFilter<SceneComponent, IsActiveComponent>.Exclude<SceneUnloadedComponent, DeactivateSceneComponent>
            _activeScenesFilter;

        private EcsFilter<SceneComponent, IsInactiveComponent>.Exclude<SceneUnloadedComponent, ActivateSceneComponent>
            _inactiveScenesFilter;

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

                foreach (var i in _inactiveScenesFilter)
                {
                    var scene = _inactiveScenesFilter.Get1(i).Scene;

                    if (!scene.SceneName.Equals(eventComponent.Name)) continue;

                    _inactiveScenesFilter.GetEntity(i).Set<ActivateSceneComponent>().IsMain = eventComponent.IsMain;

                    // idea behind this 'break' to reduce complexity of this loop,
                    // but with this it is impossible to mark scenes with the same name,
                    // which is possible if the same scene was loaded multiple times.  
                    // break;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _DeactivateScene()
        {
            foreach (var idx in _deactivateFilter)
            {
                var eventComponent = _deactivateFilter.Get1(idx);

                foreach (var i in _activeScenesFilter)
                {
                    var scene = _activeScenesFilter.Get1(i).Scene;

                    if (!scene.SceneName.Equals(eventComponent.Name)) continue;

                    _activeScenesFilter.GetEntity(i).Set<DeactivateSceneComponent>();

                    // idea behind this 'break' to reduce complexity of this loop,
                    // but with this it is impossible to mark scenes with the same name,
                    // which is possible if the same scene was loaded multiple times.  
                    // break;
                }
            }
        }
    }
}
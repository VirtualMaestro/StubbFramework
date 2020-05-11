using Leopotam.Ecs;
using StubbFramework.Common.Components;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class DeactivateSceneSystem : IEcsRunSystem
    {
        private EcsFilter<SceneComponent, IsActiveComponent, DeactivateSceneComponent> _deactivateFilter;

        public void Run()
        {
            if (_deactivateFilter.IsEmpty()) return;

            foreach (var idx in _deactivateFilter)
            {
                _deactivateFilter.Get1(idx).Scene.HideContent();

                ref var entity = ref _deactivateFilter.GetEntity(idx);
                entity.Del<IsActiveComponent>();
                entity.Get<IsInactiveComponent>();
                entity.Get<SceneChangedStateComponent>();
            }
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class ActivateSceneSystem : IEcsRunSystem
    {
        private EcsFilter<SceneComponent, IsSceneInactiveComponent, ActivateSceneComponent> _activateFilter;

        public void Run()
        {
            if (_activateFilter.IsEmpty()) return;

            foreach (var idx in _activateFilter)
            {
                ref var entity = ref _activateFilter.GetEntity(idx);
                var sceneController = _activateFilter.Get1(idx).Scene;
                var isMain = _activateFilter.Get3(idx).IsMain;

                entity.Del<IsSceneInactiveComponent>();
                entity.Get<IsSceneActiveComponent>();
                entity.Get<SceneChangedStateComponent>();

                sceneController.ShowContent();

                if (isMain) sceneController.SetAsMain();
            }
        }
    }
}
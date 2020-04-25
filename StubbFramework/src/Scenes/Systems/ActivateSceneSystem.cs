using Leopotam.Ecs;
using StubbFramework.Common.Components;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class ActivateSceneSystem : IEcsRunSystem
    {
        private EcsFilter<SceneComponent, IsInactiveComponent, ActivateSceneComponent> _activateFilter;

        public void Run()
        {
            if (_activateFilter.IsEmpty()) return;

            foreach (var idx in _activateFilter)
            {
#if DEBUG            
                if (_activateFilter.GetEntity(idx).Has<IsActiveComponent>())
                    throw new System.Exception($"Try to activate scene with name '{_activateFilter.Get1(idx).Scene.SceneName}' which is already activated!");
#endif
                
                ref var entity = ref _activateFilter.GetEntity(idx);
                var sceneController = _activateFilter.Get1(idx).Scene;
                var isMain = _activateFilter.Get3(idx).IsMain;

                entity.Unset<IsInactiveComponent>();
                entity.Set<IsActiveComponent>();
                entity.Set<SceneChangedStateComponent>();

                sceneController.ShowContent();

                if (isMain) sceneController.SetAsMain();
            }
        }
    }
}
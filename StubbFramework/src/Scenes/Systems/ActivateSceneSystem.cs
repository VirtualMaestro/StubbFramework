﻿using Leopotam.Ecs;
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
        private EcsFilter<SceneComponent, IsInactiveComponent, ActivateSceneEvent> _eventFilter;

        public void Run()
        {
            if (_eventFilter.IsEmpty()) return;

            foreach (var idx in _eventFilter)
            {
                ref var entity = ref _eventFilter.GetEntity(idx);
                ref var sceneComponent = ref _eventFilter.Get1(idx);
                var sceneController = sceneComponent.Scene;
                var isMain = _eventFilter.Get3(idx).IsMain;

                entity.Unset<IsInactiveComponent>();
                entity.Set<IsActiveComponent>();
                entity.Set<IsSceneStateChangedComponent>();

                sceneController.ShowContent();

                if (isMain) sceneController.SetAsMain();
            }
        }
    }
}
﻿using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public class UnloadNonNewScenesSystem : EcsSystem
    {
        private EcsFilter<UnloadNonNewScenesComponent> _filter;
        private EcsFilter<SceneServiceComponent> _serviceFilter;
        private EcsFilter<SceneComponent>.Exclude<NewSceneMarkerComponent> _nonNewScenesFilter;
        
        public override void Run()
        {
            if (_filter.IsEmpty()) return;

            foreach (var idx in _nonNewScenesFilter)
            {
                _RemoveScene(idx);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _RemoveScene(int entityIndex)
        {
            ref var entity = ref _nonNewScenesFilter.Entities[entityIndex];
            ISceneController controller = entity.Get<SceneComponent>().Scene;
            _serviceFilter.Single().SceneService.Unload(controller);
            controller.Destroy();
            entity.Destroy();
        }
    }
}
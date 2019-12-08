﻿using Leopotam.Ecs;
using StubbFramework.Delay.Components;
using StubbFramework.Remove.Components;
using StubbFramework.View.Components;

namespace StubbFramework.View.Systems
{
    public sealed class RemoveViewSystem : IEcsRunSystem
    {
        private EcsFilter<ViewComponent, RemoveEntityComponent>.Exclude<DelayComponent> _removeViewFilter;
            
        public void Run()
        {
            foreach (var idx in _removeViewFilter)
            {
                var view = _removeViewFilter.Get1[idx].View;
                view.Dispose();
            }
        }
    }
}
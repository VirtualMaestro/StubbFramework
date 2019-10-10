using Leopotam.Ecs;
using StubbFramework.Remove.Components;
using StubbFramework.Time;
using StubbFramework.Time.Components;

namespace StubbFramework.Remove.Systems
{
    public sealed class RemoveEntitySystem : EcsSystem
    {
        EcsFilter<RemoveEntityComponent> _removeEntityFilter;
        EcsFilter<RemoveEntityDelayComponent> _removeEntityDelayFilter;
        EcsFilter<TimeComponent> _timeFilter;
        
        public override void Run()
        {
            foreach (var index in _removeEntityFilter)
            {
                _removeEntityFilter.Entities[index].Destroy();
            }

            var timeComponent = _timeFilter.Get1[0];

            foreach (var index in _removeEntityDelayFilter)
            {
                var delayComponent = _removeEntityDelayFilter.Get1[index];
                delayComponent.Frames--;
                delayComponent.Milliseconds -= timeComponent.ElapsedMilliseconds;

                if (delayComponent.Frames > 0 || delayComponent.Milliseconds > 0) continue;
                _removeEntityDelayFilter.Entities[index].Destroy();
            }
        }
    }
}
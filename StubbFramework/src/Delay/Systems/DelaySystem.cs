using Leopotam.Ecs;
using StubbFramework.Delay.Components;
using StubbFramework.Time.Components;

namespace StubbFramework.Delay.Systems
{
    public sealed class DelaySystem : EcsSystem
    {
        private EcsFilter<DelayComponent> _filterDelay;
        private EcsFilter<TimeComponent> _filterTime;
        
        public override void Run()
        {
            var time = _filterTime.Get1[0];
            
            foreach (var index in _filterDelay)
            {
                var delay = _filterDelay.Get1[index];
                delay.Frames--;
                delay.Milliseconds -= time.TimeStep;

                if (delay.Frames <= 0 && delay.Milliseconds <= 0)
                {
                    _filterDelay.Entities[index].Unset<DelayComponent>();
                }
            }
        }
    }
}
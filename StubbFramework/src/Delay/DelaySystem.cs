using Leopotam.Ecs;
using StubbFramework.Time;

namespace StubbFramework.Delay
{
    public class DelaySystem : EcsSystem
    {
        private EcsFilter<DelayComponent> _filterDelay;
        private EcsFilter<TimeComponent> _filterTime;
        
        public override void Initialize()
        {
            _filterDelay = World.GetFilter<EcsFilter<DelayComponent>>();
            _filterTime = World.GetFilter<EcsFilter<TimeComponent>>();
        }

        public override void Run()
        {
            var time = _filterTime.Components1[0];
            
            foreach (var index in _filterDelay)
            {
                var delay = _filterDelay.Components1[index];
                delay.Frames--;
                delay.Milliseconds -= time.TimeStep;

                if (delay.Frames <= 0 && delay.Milliseconds <= 0)
                {
                    World.RemoveComponent<DelayComponent>(_filterDelay.Entities[index]);
                }
            }
        }
    }
}
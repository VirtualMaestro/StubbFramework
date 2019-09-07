using Leopotam.Ecs;
using StubbFramework.Time;

namespace StubbFramework.Remove
{
    public sealed class RemoveEntitySystem : EcsSystem
    {
        private EcsFilter<RemoveEntityComponent> _removeEntityFilter;
        private EcsFilter<RemoveEntityDelayComponent> _removeEntityDelayFilter;
        private EcsFilter<TimeComponent> _timeFilter;
        
        public override void Initialize()
        {
            _removeEntityFilter = World.GetFilter<EcsFilter<RemoveEntityComponent>>();
            _removeEntityDelayFilter = World.GetFilter<EcsFilter<RemoveEntityDelayComponent>>();
            _timeFilter = World.GetFilter<EcsFilter<TimeComponent>>();
        }

        public override void Run()
        {
            foreach (var index in _removeEntityFilter)
            {
                ref var entity = ref _removeEntityFilter.Entities[index];
                World.RemoveEntity(entity);
            }

            var timeComponent = _timeFilter.Components1[0];

            foreach (var index in _removeEntityDelayFilter)
            {
                var delayComponent = _removeEntityDelayFilter.Components1[index];
                delayComponent.Frames--;
                delayComponent.Milliseconds -= timeComponent.ElapsedMilliseconds;

                if (delayComponent.Frames > 0 || delayComponent.Milliseconds > 0) continue;
                ref var entity = ref _removeEntityDelayFilter.Entities[index];
                World.RemoveEntity(entity);
            }
        }
    }
}
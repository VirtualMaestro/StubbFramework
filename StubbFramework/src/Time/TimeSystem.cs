using System.Diagnostics;
using Leopotam.Ecs;

namespace StubbFramework.Time
{
    public sealed class TimeSystem : EcsSystem
    {
        private EcsFilter<TimeComponent> _filter;

        public override void Initialize()
        {
            _filter = World.GetFilter<EcsFilter<TimeComponent>>();
            World.CreateEntityWith<TimeComponent>(out var timeComponent);
            timeComponent.Stopwatch = new Stopwatch();
            timeComponent.ElapsedMilliseconds = 0;
            timeComponent.PrevElapsedMilliseconds = 0;
            timeComponent.ElapsedFrames = 0;
            timeComponent.TimeStep = 0;
            timeComponent.Stopwatch.Start();
        }

        public override void Run()
        {
            var timeComponent = _filter.Components1[0];
            long currentTime = timeComponent.Stopwatch.ElapsedMilliseconds;
            timeComponent.PrevElapsedMilliseconds = timeComponent.ElapsedMilliseconds;
            timeComponent.TimeStep = currentTime - timeComponent.PrevElapsedMilliseconds;
            timeComponent.ElapsedMilliseconds = currentTime;
            timeComponent.ElapsedFrames++;
        }
    }
}
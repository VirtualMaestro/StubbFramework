using System.Diagnostics;
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Time.Components;

namespace StubbFramework.Time.Systems
{
    public sealed class TimeSystem : EcsSystem
    {
        EcsFilter<TimeComponent> _timeFilter;

        public override void Init()
        {
            World.NewEntityWith<TimeComponent>(out var timeComponent);
            timeComponent.Stopwatch = new Stopwatch();
            timeComponent.ElapsedMilliseconds = 0;
            timeComponent.PrevElapsedMilliseconds = 0;
            timeComponent.ElapsedFrames = 0;
            timeComponent.TimeStep = 0;
            timeComponent.Stopwatch.Start();
        }

        public override void Run()
        {
            var timeComponent = _timeFilter.Single();
            long currentTime = timeComponent.Stopwatch.ElapsedMilliseconds;
            timeComponent.PrevElapsedMilliseconds = timeComponent.ElapsedMilliseconds;
            timeComponent.TimeStep = currentTime - timeComponent.PrevElapsedMilliseconds;
            timeComponent.ElapsedMilliseconds = currentTime;
            timeComponent.ElapsedFrames++;
        }
    }
}
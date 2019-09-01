using System.Diagnostics;
using Leopotam.Ecs;

namespace StubbFramework.Time
{
    
    public class TimeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<TimeComponent> _filter;
        
        public TimeSystem(EcsWorld world)
        {
            _filter = world.GetFilter<EcsFilter<TimeComponent>>();
            world.CreateEntityWith<TimeComponent>(out var timeComponent);
            timeComponent.Stopwatch = new Stopwatch();
            timeComponent.ElapsedMilliseconds = 0;
            timeComponent.PrevElapsedMilliseconds = 0;
            timeComponent.ElapsedFrames = 0;
            timeComponent.TimeStep = 0;
        }
        
        public void Initialize()
        {
            var timeComponent = _filter.Components1[0];
            timeComponent.Stopwatch.Start();
        }

        public void Destroy()
        {
            
        }

        public void Run()
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
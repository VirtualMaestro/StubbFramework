using System.Diagnostics;
using Leopotam.Ecs;
using StubbFramework.Time.Components;

namespace StubbFramework.Time.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class TimeSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld World;
        private EcsFilter<TimeComponent> _timeFilter;

        public void Init()
        {
            ref var timeComponent = ref World.NewEntity().Get<TimeComponent>();
            timeComponent.Stopwatch = new Stopwatch();
            timeComponent.ElapsedMilliseconds = 0;
            timeComponent.PrevElapsedMilliseconds = 0;
            timeComponent.ElapsedFrames = 0;
            timeComponent.TimeStep = 0;
            timeComponent.Stopwatch.Start();
        }

        public void Run()
        {
            foreach (var idx in _timeFilter)
            {
                ref var timeComponent = ref _timeFilter.Get1(idx);
                var currentTime = timeComponent.Stopwatch.ElapsedMilliseconds;
                timeComponent.PrevElapsedMilliseconds = timeComponent.ElapsedMilliseconds;
                timeComponent.TimeStep = currentTime - timeComponent.PrevElapsedMilliseconds;
                timeComponent.ElapsedMilliseconds = currentTime;
                timeComponent.ElapsedFrames++;
            }
        }

        public void Destroy()
        {
            foreach (var idx in _timeFilter)
            {
                var stopwatch = _timeFilter.Get1(idx).Stopwatch;
                stopwatch?.Stop();
            }
        }
    }
}
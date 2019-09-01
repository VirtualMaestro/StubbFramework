using System.Diagnostics;
using Leopotam.Ecs;

namespace StubbFramework.Time
{
    public class TimeComponent : IEcsAutoResetComponent
    {
        public Stopwatch Stopwatch;
        public long PrevElapsedMilliseconds;
        public long ElapsedMilliseconds;
        public long ElapsedFrames;
        public long TimeStep;
        
        public void Reset()
        {
            Stopwatch.Stop();
            Stopwatch = null;
        }
    }
}
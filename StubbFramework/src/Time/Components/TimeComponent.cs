using System.Diagnostics;

namespace StubbFramework.Time.Components
{
    /// <summary>
    /// Contains info about time:
    /// - TimeStep - how many milliseconds passed since last frame.
    /// - ElapsedMilliseconds - how many milliseconds have passed since application started. 
    /// - ElapsedFrames - how many frames have passed since application started. 
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct TimeComponent
    {
        public Stopwatch Stopwatch;
        public long PrevElapsedMilliseconds;
        public long ElapsedMilliseconds;
        public long ElapsedFrames;
        public long TimeStep;
    }
}
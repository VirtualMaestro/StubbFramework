using Leopotam.Ecs;

namespace StubbFramework.Common.Components
{
    /// <summary>
    /// One-frame generic event-component which determines is some entity or process new.
    /// Component will be removed at end of the frame.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct IsNewEvent : IEcsIgnoreInFilter
    {}
}
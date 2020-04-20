using Leopotam.Ecs;

namespace StubbFramework.Common.Components
{
    /// <summary>
    /// Generic marker-component which determines if some process was complete.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct IsCompleteComponent : IEcsIgnoreInFilter
    {
    }
}
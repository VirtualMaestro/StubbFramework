using Leopotam.Ecs;

namespace StubbFramework.Common.Components
{
    /// <summary>
    /// Generic state-component which determines is some entity or process inactive.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct IsInactiveComponent : IEcsIgnoreInFilter
    {
    }
}
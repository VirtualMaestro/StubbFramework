using Leopotam.Ecs;

namespace StubbFramework.Remove.Components
{
    /// <summary>
    /// The component is attached to an entity which should be removed at the end of the loop.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct RemoveEntityComponent : IEcsIgnoreInFilter
    {}
}
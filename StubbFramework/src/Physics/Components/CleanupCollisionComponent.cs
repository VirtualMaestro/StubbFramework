using Leopotam.Ecs;

namespace StubbFramework.Physics.Components
{
    /// <summary>
    /// For internal use.
    /// It is added to all collision component automatically (e.g. CollisionEnterComponent) in order to be destroyed in CleanupCollisionSystem.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct CleanupCollisionComponent : IEcsIgnoreInFilter
    {
    }
}
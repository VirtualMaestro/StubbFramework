using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// It is state-component which determines whether scene at the moment active.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct IsSceneInactiveComponent : IEcsIgnoreInFilter
    {
    }
}
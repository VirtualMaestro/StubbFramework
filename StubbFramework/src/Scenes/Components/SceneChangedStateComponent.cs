using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// One-frame marker-component which determines whether state (active/inactive) of a scene was changed.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct SceneChangedStateComponent : IEcsIgnoreInFilter
    {
    }
}
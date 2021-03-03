using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// One-frame component determines is a scene was loaded.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct SceneLoadedComponent : IEcsIgnoreInFilter
    {
    }
}
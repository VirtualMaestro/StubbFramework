using Leopotam.Ecs;

namespace StubbFramework.Scenes.Events
{
    /// <summary>
    /// Event-component which is sent when need to unload all scenes.
    /// Component will be removed at the end of the frame.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct UnloadAllScenesEvent : IEcsIgnoreInFilter
    {
    }
}
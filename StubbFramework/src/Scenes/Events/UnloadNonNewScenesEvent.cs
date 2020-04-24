using Leopotam.Ecs;

namespace StubbFramework.Scenes.Events
{
    /// <summary>
    /// Event-component will be sent when all scenes which are not marked with IsNewComponent need to be unloaded.
    /// So, all non-new scenes will be unloaded.
    /// Component will be removed at the end of the frame.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct UnloadNonNewScenesEvent : IEcsIgnoreInFilter
    {}
}
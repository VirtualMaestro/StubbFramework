using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Event-component can be sent when need to deactivate scene by attaching it to the entity of the scene.
    /// For convenience sake it is better to use World.DeactivateScene().
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct DeactivateSceneEvent : IEcsIgnoreInFilter
    {
    }
}
using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Will be sent when all scenes which are not marked with NewSceneMarkerComponent need to be unloaded
    /// </summary>
    public class UnloadNonNewScenesComponent : IEcsOneFrame, IEcsIgnoreInFilter
    {}
}
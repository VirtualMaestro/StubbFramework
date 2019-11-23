using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Will be added to every new created scene (Need only for bunch scene loading)
    /// </summary>
    public sealed class NewSceneMarkerComponent : IEcsOneFrame, IEcsIgnoreInFilter
    {}
}
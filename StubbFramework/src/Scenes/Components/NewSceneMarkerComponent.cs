using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component will be added to the scene which was just loaded and will be removed automatically.
    /// </summary>
    public class NewSceneMarkerComponent : IEcsIgnoreInFilter
    {}
}
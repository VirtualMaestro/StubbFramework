using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component (as an event) is sent when a scene become inactive (content of the scene).
    /// IMPORTANT: You will not get this component if scene was unload.
    /// </summary>
    /// TODO: Rework and send SceneController instead of its name;
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct SceneDeactivatedEvent
    {
        public IAssetName SceneName;
    }
}
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Events
{
    /// <summary>
    /// Event-component can be sent when need to deactivate scene by its name.
    /// For convenience sake it is better to use World.DeactivateSceneByName().
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct DeactivateSceneByNameEvent
    {
        public IAssetName Name;
    }
}
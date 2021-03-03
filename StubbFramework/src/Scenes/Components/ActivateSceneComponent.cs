namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// One-frame component which should be attached to the scene controller entity if this scene needs to be activated.
    /// For convenience use World.ActivateScene().  
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct ActivateSceneComponent
    {
        public bool IsMain;
    }
}
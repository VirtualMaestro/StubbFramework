namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Contains reference to the ISceneController which contains a ref to the scene (or part of the scene).
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct SceneComponent
    {
        public ISceneController Scene;
    }
}
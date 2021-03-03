using System.Collections.Generic;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Contains list of the progresses for loading scenes.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct ActiveLoadingScenesComponent
    {
        public List<ISceneLoadingProgress> Progresses;
        public List<IAssetName> UnloadScenes;
        public bool UnloadOthers;
    }
}
using System.Collections.Generic;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Event-component is sent when some set of the scenes should be unloaded.
    /// Component will be removed at the end of the frame.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct UnloadScenesByNamesEvent
    {
        public IList<IAssetName> SceneNames;
    }
}
using System.Collections.Generic;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Event is sent when some set of the scenes should be unloaded.
    /// If SceneNames is null will be unloaded all the scenes.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct UnloadScenesEvent
    {
        public IList<IAssetName> SceneNames;
    }
}
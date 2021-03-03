using System.Collections.Generic;
using StubbFramework.Common.Names;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Events
{
    /// <summary>
    /// Event-component is sent when need to load one or bunch scenes. Will be removed at the end of the loop
    /// For convenience use World.LoadScenes().
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct LoadScenesEvent
    {
        /// <summary>
        /// List of the scenes configurations.
        /// </summary>
        public List<ILoadingSceneConfig> LoadingScenes;
        /// <summary>
        /// List of the names for the scenes which have to be unloaded when scenes from the LoadingScenes have been loaded.
        /// </summary>
        public List<IAssetName> UnloadingScenes;
        /// <summary>
        /// Param show whether others scenes will be unloaded when LoadingScenes have been loaded.
        /// </summary>
        public bool UnloadOthers;
    }
}
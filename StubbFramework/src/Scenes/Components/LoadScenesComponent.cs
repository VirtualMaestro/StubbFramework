﻿using System.Collections.Generic;
using StubbFramework.Common.Names;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct LoadScenesComponent
    {
        public List<ILoadingSceneConfig> LoadingScenes;
        public List<IAssetName> UnloadingScenes;
        public bool UnloadOthers;
    }
}
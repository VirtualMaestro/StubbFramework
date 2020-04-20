﻿using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct ActivateSceneComponent
    {
        public IAssetName Name;
        public bool Active;
        public bool IsMain;
    }
}
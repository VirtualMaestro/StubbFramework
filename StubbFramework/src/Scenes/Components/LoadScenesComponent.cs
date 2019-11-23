using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Common.Names;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
    public sealed class LoadScenesComponent : IEcsAutoReset
    {
        public List<ILoadingSceneConfig> LoadingScenes;
        public List<IAssetName> UnloadingScenes;
        public bool UnloadOthers;
        
        public void Reset()
        {
            LoadingScenes = null;
            UnloadingScenes = null;
            UnloadOthers = false;
        }
    }
}
using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
    public class LoadScenesComponent : IEcsAutoReset
    {
        public IList<ILoadingSceneConfig> LoadingScenes;
        public IList<ISceneName> UnloadingScenes;
        public bool UnloadOthers;
        
        public void Reset()
        {
            LoadingScenes = null;
            UnloadingScenes = null;
        }
    }
}
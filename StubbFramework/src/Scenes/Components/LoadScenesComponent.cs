using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
    public class LoadScenesComponent : IEcsAutoReset
    {
        public ILoadingScenesConfig LoadingScenes;
        public IList<ISceneName> UnloadingScenes;
        
        public void Reset()
        {
            LoadingScenes = null;
            UnloadingScenes = null;
        }
    }
}
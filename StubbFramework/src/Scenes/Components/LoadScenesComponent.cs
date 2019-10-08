using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
    public class LoadScenesComponent : IEcsAutoReset
    {
        public ILoadingScenesConfig Config;
        public IList<ISceneName> UnloadScenes;
        
        public void Reset()
        {
            Config = null;
            UnloadScenes = null;
        }
    }
}
using System.Collections.Generic;
using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component contains list of progresses of scenes loading.
    /// </summary>
    public class ActiveLoadingScenesComponent : IEcsAutoReset
    {
        public IList<ISceneLoadingProgress> Progresses;
        public IList<ISceneName> UnloadScenes;
        public bool UnloadOthers;
        
        public void Reset()
        {
            Progresses = null;
            UnloadScenes = null;
        }
    }
}
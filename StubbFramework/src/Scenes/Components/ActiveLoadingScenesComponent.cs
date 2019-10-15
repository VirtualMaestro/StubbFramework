using System.Collections.Generic;
using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component contains list of progresses of scenes loading.
    /// </summary>
    public class ActiveLoadingScenesComponent : IEcsAutoReset
    {
        public bool IsActivatingAll;
        public ISceneLoadingProgress[] Progresses;
        public IList<ISceneName> UnloadScenes;
        public bool UnloadAllOtherScenes;
        
        public void Reset()
        {
            IsActivatingAll = false;
            Progresses = null;
            UnloadScenes = null;
        }
    }
}
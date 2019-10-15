using System.Collections.Generic;
using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// If SceneNames is null will be unloaded all the current scenes.
    /// </summary>
    public class UnloadScenesComponent : IEcsAutoReset
    {
        public IList<ISceneName> SceneNames;
        
        public void Reset()
        {
            SceneNames = null;
        }
    }
}
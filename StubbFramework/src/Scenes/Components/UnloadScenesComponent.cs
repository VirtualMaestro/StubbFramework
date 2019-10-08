using System.Collections.Generic;
using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    public class UnloadScenesComponent : IEcsAutoReset
    {
        public IList<ISceneName> SceneNames;
        
        public void Reset()
        {
            SceneNames = null;
        }
    }
}
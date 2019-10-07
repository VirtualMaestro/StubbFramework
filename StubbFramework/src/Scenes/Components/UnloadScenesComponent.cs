using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    public class UnloadScenesComponent : IEcsAutoReset
    {
        public string[] SceneNames;
        
        public void Reset()
        {
            SceneNames = null;
        }
    }
}
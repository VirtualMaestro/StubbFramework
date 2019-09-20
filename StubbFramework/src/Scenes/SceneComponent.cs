using Leopotam.Ecs;

namespace StubbFramework.Scenes
{
    public class SceneComponent : IEcsAutoResetComponent
    {
        public ISceneController scene;
        
        public void Reset()
        {
            scene = null;
        }
    }
}
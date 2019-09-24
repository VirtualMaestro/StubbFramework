using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component contains reference to the ISceneController which contains Scene which is loaded.
    /// </summary>
    public class SceneComponent : IEcsAutoResetComponent
    {
        public ISceneController Scene;
        
        public void Reset()
        {
            Scene = null;
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
    public class LoadScenesComponent : IEcsAutoResetComponent
    {
        public ISceneLoadingListConfig Scenes;
        public string[] UnloadScenes;
        
        public void Reset()
        {
            Scenes = null;
            UnloadScenes = null;
        }
    }
}
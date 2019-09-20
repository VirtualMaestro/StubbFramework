namespace StubbFramework.Scenes.Configurations
{
    public class SceneLoadingConfig : ISceneLoadingConfig
    {
        public string SceneName { get; }

        public bool IsAdditive { get; set; }
        public bool IsActive { get; set; }
        public bool IsProcessed { get; private set; }

        public SceneLoadingConfig(string sceneName)
        {
            SceneName = sceneName;
        }
        
        public void MarkProcessed()
        {
            IsProcessed = true;
        }

        public ISceneLoadingConfig Clone()
        {
            return new SceneLoadingConfig(SceneName) {IsActive = IsActive, IsAdditive = IsAdditive};
        }
    }
}
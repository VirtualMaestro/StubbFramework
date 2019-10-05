namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public string SceneName { get; }
        public bool IsAdditive { get; set; }
        public bool IsActive { get; set; }

        public LoadingSceneConfig(string sceneName)
        {
            SceneName = sceneName;
        }

        public ILoadingSceneConfig Clone()
        {
            return new LoadingSceneConfig(SceneName) {IsActive = IsActive, IsAdditive = IsAdditive};
        }
    }
}
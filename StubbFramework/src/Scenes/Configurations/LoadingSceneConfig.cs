namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public string SceneName { get; }
        public string ScenePath { get; }
        public bool IsAdditive { get; }

        public LoadingSceneConfig(string sceneName, string scenePath = null, bool isAdditive = true)
        {
            SceneName = sceneName;
            ScenePath = scenePath;
            IsAdditive = isAdditive;
        }

        public ILoadingSceneConfig Clone()
        {
            return new LoadingSceneConfig(SceneName, ScenePath, IsAdditive);
        }
    }
}
namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public ISceneName Name { get; }
        public bool IsAdditive { get; }

        public LoadingSceneConfig(ISceneName name, bool isAdditive = true)
        {
            Name = name;
            IsAdditive = isAdditive;
        }

        public ILoadingSceneConfig Clone()
        {
            return new LoadingSceneConfig(Name.Clone(), IsAdditive);
        }
    }
}
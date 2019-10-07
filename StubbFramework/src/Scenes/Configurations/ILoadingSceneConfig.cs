namespace StubbFramework.Scenes.Configurations
{
    public interface ILoadingSceneConfig
    {
        ISceneName Name { get; }
        bool IsAdditive { get; }
        ILoadingSceneConfig Clone();
     }
}
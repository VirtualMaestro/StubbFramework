namespace StubbFramework.Scenes.Configurations
{
    public interface ILoadingSceneConfig
    {
        string SceneName { get; }
        string ScenePath { get; }
        bool IsAdditive { get; }
        ILoadingSceneConfig Clone();
     }
}
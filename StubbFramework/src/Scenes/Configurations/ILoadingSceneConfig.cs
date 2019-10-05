namespace StubbFramework.Scenes.Configurations
{
    public interface ILoadingSceneConfig
    {
        string SceneName { get; }
        bool IsAdditive { get; set; }
        bool IsActive { get; set; }
        ILoadingSceneConfig Clone();
     }
}
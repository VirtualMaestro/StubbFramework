namespace StubbFramework.Scenes.Configurations
{
    public interface ISceneLoadingConfig
    {
        string SceneName { get; }
        bool IsAdditive { get; set; }
        bool IsActive { get; set; }
        bool IsProcessed { get; }
        void MarkProcessed();
        ISceneLoadingConfig Clone();
     }
}
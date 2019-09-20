namespace StubbFramework.Scenes.Configurations
{
    public interface ISceneLoadingListConfig
    {
        bool IsProcessed { get; }
        bool IsActive { get; }
        ISceneLoadingListConfig Add(ISceneLoadingConfig config);
        
    }
}
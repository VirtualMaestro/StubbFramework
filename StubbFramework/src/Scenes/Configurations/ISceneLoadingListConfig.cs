namespace StubbFramework.Scenes.Configurations
{
    public interface ISceneLoadingListConfig
    {
        string Name { get; }
        bool IsActive { get; }
        bool IsEmpty { get; }
        ISceneLoadingListConfig Add(ISceneLoadingConfig config);
        void Remove(string sceneName);
        ISceneLoadingListConfig Clone();
    }
}
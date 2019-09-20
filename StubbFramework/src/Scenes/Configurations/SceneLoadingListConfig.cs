namespace StubbFramework.Scenes.Configurations
{
    public class SceneLoadingListConfig : ISceneLoadingListConfig
    {
        public bool IsProcessed { get; }
        public bool IsActive { get; }
        public ISceneLoadingListConfig Add(ISceneLoadingConfig config)
        {
            throw new System.NotImplementedException();
        }
    }
}
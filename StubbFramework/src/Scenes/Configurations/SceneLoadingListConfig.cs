namespace StubbFramework.Scenes.Configurations
{
    public class SceneLoadingListConfig : ISceneLoadingListConfig
    {
        public string Name { get; }
        public bool IsActive { get; }
        public bool IsEmpty { get; }

        public ISceneLoadingListConfig Add(ISceneLoadingConfig config)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(string sceneName)
        {
            throw new System.NotImplementedException();
        }

        public ISceneLoadingListConfig Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
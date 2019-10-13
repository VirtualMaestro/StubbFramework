namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public ISceneName Name { get; }
        public bool IsActive { get; }
        public bool IsMain { get; }
        public bool IsSingle { get; }
        public object Payload { get; set; }

        public LoadingSceneConfig(ISceneName name, bool isActive = true, bool isMain = false, bool isSingle = false)
        {
            Name = name;
            IsActive = isActive;
            IsMain = isMain;
            IsSingle = isSingle;
        }

        public ILoadingSceneConfig Clone()
        {
            return new LoadingSceneConfig(Name.Clone(), IsActive, IsMain, IsSingle) {Payload = Payload};
        }
    }
}
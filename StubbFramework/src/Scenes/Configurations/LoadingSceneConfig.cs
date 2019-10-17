namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public static LoadingSceneConfigBuilder Create(ISceneName sceneName)
        {
            return new LoadingSceneConfigBuilder (sceneName);
        }
        
        public ISceneName Name { get; }
        public bool IsActive { get; internal set; }
        public bool IsMain { get; internal set; }
        public bool IsSingle { get; internal set; }
        public object Payload { get; set; }

        public LoadingSceneConfig(ISceneName sceneName)
        {
            Name = sceneName;
            IsActive = true;
            IsMain = false;
            IsSingle = false;
        }
       
        public ILoadingSceneConfig Clone()
        {
            var copy = new LoadingSceneConfig(Name.Clone())
            {
                IsActive = IsActive, IsMain = IsMain, IsSingle = IsSingle, Payload = Payload
            };
            return copy;
        }
    }

    public class LoadingSceneConfigBuilder
    {
        private readonly LoadingSceneConfig _config;
        
        public LoadingSceneConfig Build => _config;

        public LoadingSceneConfigBuilder(ISceneName sceneName)
        {
            _config = new LoadingSceneConfig(sceneName);
        }

        public LoadingSceneConfigBuilder IsActive(bool isActive)
        {
            _config.IsActive = isActive;
            return this;
        }

        public LoadingSceneConfigBuilder IsMain(bool isMain)
        {
            _config.IsMain = isMain;
            return this;
        }

        public LoadingSceneConfigBuilder IsSingle(bool isSingle)
        {
            _config.IsSingle = isSingle;
            return this;
        }
        
        public LoadingSceneConfigBuilder WithPayload(object payload)
        {
            _config.Payload = payload;
            return this;
        }
    }
}
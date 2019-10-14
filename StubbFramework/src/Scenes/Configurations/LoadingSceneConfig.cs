namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public static LoadingSceneConfigBuilder Create(string sceneName, string scenePath = null)
        {
            return new LoadingSceneConfigBuilder (sceneName, scenePath);
        }
        
        public ISceneName Name { get; }
        public bool IsActive { get; internal set; }
        public bool IsMain { get; internal set; }
        public bool IsSingle { get; internal set; }
        public object Payload { get; set; }

        public LoadingSceneConfig(string sceneName, string scenePath = null)
        {
            Name = new SceneName(sceneName, scenePath);
            IsActive = true;
            IsMain = false;
            IsSingle = false;
        }
       
        public ILoadingSceneConfig Clone()
        {
            var copy = new LoadingSceneConfig(Name.Name, Name.Path)
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

        public LoadingSceneConfigBuilder(string sceneName, string scenePath = null)
        {
            _config = new LoadingSceneConfig(sceneName, scenePath);
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
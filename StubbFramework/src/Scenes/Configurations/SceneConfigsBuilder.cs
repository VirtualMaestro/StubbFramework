using System.Collections.Generic;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Configurations
{
    public class SceneConfigsBuilder<T, S> where T : ILoadingSceneConfig, new() where S : IAssetName, new()
    {
        public static SceneConfigsBuilder<T, S> Create => new SceneConfigsBuilder<T, S>();

        private readonly List<ILoadingSceneConfig> _configs;
        private ILoadingSceneConfig _currentConfig;

        public SceneConfigsBuilder()
        {
            _configs = new List<ILoadingSceneConfig>();
        }

        public SceneConfigsBuilder<T, S> Add(in S sceneName)
        {
            _currentConfig = new T();
            _configs.Add(_currentConfig);
            return this;
        }

        public SceneConfigsBuilder<T, S> IsActive(bool value)
        {
            _currentConfig.IsActive = value;
            return this;
        }

        public SceneConfigsBuilder<T, S> IsMain(bool value)
        {
            _currentConfig.IsMain = value;
            return this;
        }

        public SceneConfigsBuilder<T, S> IsMultiple(bool value)
        {
            _currentConfig.IsMultiple = value;
            return this;
        }

        public SceneConfigsBuilder<T, S> WithPayload(object value)
        {
            _currentConfig.Payload = value;
            return this;
        }

        public List<ILoadingSceneConfig> Build
        {
            get
            {
                _currentConfig = null;
                return _configs;
            }
        }
    }
}
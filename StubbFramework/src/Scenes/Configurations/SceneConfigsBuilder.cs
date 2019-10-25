using System.Collections.Generic;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Configurations
{
    public class SceneConfigsBuilder<T, S> where T: ILoadingSceneConfig, new() where S: IAssetName, new()
    {
        public static SceneConfigsBuilder<T, S> Create => new SceneConfigsBuilder<T, S>();
        
        private readonly List<ILoadingSceneConfig> _configs;

        public SceneConfigsBuilder()
        {
            _configs = new List<ILoadingSceneConfig>();
        }

        public SceneConfigsBuilder<T, S> Add(string sceneName, string scenePath = null, bool isActive = true, bool isMain = false, object payload = null)
        {
            var config = new T();
            S name = new S();
            name.Set(sceneName, scenePath);
            config.Set(name, isActive, isMain);
            config.Payload = payload;
            _configs.Add(config);
            
            return this;
        }
        
        public List<ILoadingSceneConfig> Build => _configs;
    }
}
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public IAssetName Name { get; }
        public bool IsActive { get; }
        public bool IsMain { get; }
        public object Payload { get; }

        public LoadingSceneConfig(IAssetName sceneName, bool isActive = true, bool isMain = false, object payload = null)
        {
            Name = sceneName;
            IsActive = isActive;
            IsMain = isMain;
            Payload = payload;
        }
       
        public ILoadingSceneConfig Clone()
        {
            return new LoadingSceneConfig(Name.Clone(), IsActive, IsMain, Payload);
        }
    }
}
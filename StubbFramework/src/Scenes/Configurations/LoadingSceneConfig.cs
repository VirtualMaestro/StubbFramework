using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public IAssetName Name { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsMain { get; private set; }
        public bool IsMultiple { get; private set; }
        public object Payload { get; set; }

        public LoadingSceneConfig()
        {
        }

        public LoadingSceneConfig(IAssetName sceneName, bool isActive = true, bool isMain = false,
            bool isMultiple = false)
        {
            Name = sceneName;
            IsActive = isActive;
            IsMain = isMain;
            IsMultiple = isMultiple;
        }

        public void Set(IAssetName name, bool isActive, bool isMain, bool isMultiple = false)
        {
            Name = name;
            IsActive = isActive;
            IsMain = isMain;
            IsMultiple = isMultiple;
        }

        public ILoadingSceneConfig Clone()
        {
            return new LoadingSceneConfig(Name.Clone(), IsActive, IsMain) {Payload = Payload};
        }
    }
}
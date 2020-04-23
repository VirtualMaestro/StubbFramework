using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Configurations
{
    public class LoadingSceneConfig : ILoadingSceneConfig
    {
        public IAssetName Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
        public bool IsMultiple { get; set; }
        public object Payload { get; set; }

        public ILoadingSceneConfig Clone()
        {
            var config = new LoadingSceneConfig
            {
                Name = Name.Clone(), IsActive = IsActive, IsMain = IsMain, Payload = Payload
            };

            return config;
        }
    }
}
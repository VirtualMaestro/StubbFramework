using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public interface ILoadingScenesConfig : IEnumerable<ILoadingSceneConfig>
    {
        bool IsActive { get; }
        bool IsEmpty { get; }
        ILoadingScenesConfig Add(ILoadingSceneConfig config);
        ILoadingScenesConfig Add(string sceneName, string scenePath = null, bool isAdditive = true);
        void Pop();
        ILoadingScenesConfig Clone();
    }
}
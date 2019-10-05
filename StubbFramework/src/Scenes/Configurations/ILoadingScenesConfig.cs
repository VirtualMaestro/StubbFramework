using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public interface ILoadingScenesConfig : IEnumerable<ILoadingSceneConfig>
    {
        string Name { get; }
        bool IsActive { get; }
        bool IsEmpty { get; }
        ILoadingScenesConfig Add(ILoadingSceneConfig config);
        ILoadingScenesConfig Add(string sceneName, bool isActive, bool isAdditive);
        void Pop();
        ILoadingScenesConfig Clone();
    }
}
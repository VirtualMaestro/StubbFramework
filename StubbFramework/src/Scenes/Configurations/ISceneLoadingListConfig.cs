using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public interface ISceneLoadingListConfig : IEnumerable<ISceneLoadingConfig>
    {
        string Name { get; }
        bool IsActive { get; }
        bool IsEmpty { get; }
        ISceneLoadingListConfig Add(ISceneLoadingConfig config);
        ISceneLoadingListConfig Add(string sceneName, bool isActive, bool isAdditive);
        void Pop();
        ISceneLoadingListConfig Clone();
    }
}
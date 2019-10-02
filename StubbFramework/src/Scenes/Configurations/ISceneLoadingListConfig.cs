using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public interface ISceneLoadingListConfig : IEnumerable<ISceneLoadingConfig>
    {
        string Name { get; }
        bool IsActive { get; }
        bool IsEmpty { get; }
        ISceneLoadingListConfig Add(ISceneLoadingConfig config);
        void Pop();
        ISceneLoadingListConfig Clone();
    }
}
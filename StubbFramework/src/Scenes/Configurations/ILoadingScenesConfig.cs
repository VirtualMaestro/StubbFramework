using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public interface ILoadingScenesConfig : IEnumerable<ILoadingSceneConfig>
    {
        /// <summary>
        /// All scenes in this bunch should be activated all together after all scenes are loaded.
        /// </summary>
        bool IsActivatingAll { get; }
        int NumScenes { get; }
        ILoadingScenesConfig Add(ILoadingSceneConfig config);
        ILoadingScenesConfig Add(string sceneName, string scenePath = null, bool isAdditive = true);
        ILoadingScenesConfig Clone();
    }
}
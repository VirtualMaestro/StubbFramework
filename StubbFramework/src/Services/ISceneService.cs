using System.Collections.Generic;
using StubbFramework.Scenes;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Services
{
   /// <summary>
   /// Access to engine specific Scene management.
   /// </summary>
    public interface ISceneService
    {
        ISceneLoadingProgress[] Load(ILoadingScenesConfig config);
        void Unload(ISceneName sceneName);
        void Unload(IList<ISceneName> sceneNames);

        void Activate(ISceneLoadingProgress[] progresses);
        void Activate(ISceneLoadingProgress progress);
    }
}
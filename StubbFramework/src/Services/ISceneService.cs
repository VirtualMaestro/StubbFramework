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
        void Unload(string sceneName);
        void Unload(string[] sceneNames);

        void Activate(ISceneLoadingProgress[] progresses);
        void Activate(ISceneLoadingProgress progress);
    }
}
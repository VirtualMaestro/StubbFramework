using StubbFramework.Scenes;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Services
{
   /// <summary>
   /// Access to engine specific Scene management.
   /// </summary>
    public interface ISceneService
    {
        ISceneLoadingProgress[] Load(in ILoadingScenesConfig config);
        
        void Unload(in ISceneController sceneController);

        void LoadingComplete(in ISceneLoadingProgress[] progresses);
        void LoadingComplete(in ISceneLoadingProgress progress);
    }
}
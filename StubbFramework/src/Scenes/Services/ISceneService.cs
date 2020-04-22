using System.Collections.Generic;
using StubbFramework.Common.Names;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Services
{
   /// <summary>
   /// Access to engine specific Scene management.
   /// </summary>
    public interface ISceneService
    {
        List<ISceneLoadingProgress> Load(in List<ILoadingSceneConfig> configs);
        void Unload(in ISceneController sceneController);
        
        /// <summary>
        /// Returns SceneController of a loaded scene.
        /// </summary>
        ISceneController GetLoadedSceneController(ISceneLoadingProgress progress);
        
        bool HasScene(in IAssetName sceneName);
        bool IsSceneReady(in IAssetName sceneName);
    }
}
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
        /// Creates and returns loaded scenes by given their loading progresses.
        /// Returns array of KeyValuePair where key is ISceneController and value is config ILoadingSceneConfig.
        /// </summary>
        /// <param name="progresses">List of ISceneLoadingProgress</param>
        /// <returns>KeyValuePair of ISceneController, ILoadingSceneConfig</returns>
        KeyValuePair<ISceneController, ILoadingSceneConfig>[] GetLoaded(List<ISceneLoadingProgress> progresses);
        
        bool HasScene(in IAssetName sceneName);
        bool IsSceneReady(in IAssetName sceneName);
    }
}
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
        IList<ISceneLoadingProgress> Load(in IList<ILoadingSceneConfig> configs);
        void Unload(in ISceneController sceneController);
        KeyValuePair<ISceneController, ILoadingSceneConfig>[] LoadingComplete(IList<ISceneLoadingProgress> progresses);
    }
}
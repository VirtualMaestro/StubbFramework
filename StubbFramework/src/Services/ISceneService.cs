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
        void LoadingComplete(IList<ISceneLoadingProgress> progresses);
    }
}
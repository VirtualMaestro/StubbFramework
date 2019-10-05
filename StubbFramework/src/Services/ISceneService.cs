using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Services
{
   /// <summary>
   /// Access to engine specific Scene management.
   /// </summary>
    public interface ISceneService
    {
        void Load(ILoadingSceneConfig config);
        void Unload(string sceneName);
        
    }
}
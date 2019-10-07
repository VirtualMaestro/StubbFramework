using Leopotam.Ecs;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component contains list of progresses of scenes loading.
    /// </summary>
    public class ActiveLoadingScenesComponent : IEcsAutoReset
    {
        public bool IsActivatingAll;
        public ISceneLoadingProgress[] Progresses;
        public string[] UnloadScenes;
        
        public void Reset()
        {
            IsActivatingAll = false;
            Progresses = null;
            UnloadScenes = null;
        }
    }
}
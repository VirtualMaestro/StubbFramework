using Leopotam.Ecs;
using StubbFramework.Scenes.Services;

namespace StubbFramework.Scenes.Components
{
    public sealed class SceneServiceComponent : IEcsAutoReset
    {
        public ISceneService SceneService;
        
        public void Reset()
        {
            SceneService = null;
        }
    }
}
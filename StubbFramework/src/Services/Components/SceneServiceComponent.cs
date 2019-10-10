using Leopotam.Ecs;

namespace StubbFramework.Services.Components
{
    public class SceneServiceComponent : IEcsAutoReset
    {
        public ISceneService SceneService;
        
        public void Reset()
        {
            SceneService = null;
        }
    }
}
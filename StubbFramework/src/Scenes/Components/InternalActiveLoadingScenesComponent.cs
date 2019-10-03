using Leopotam.Ecs;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
    public class InternalActiveLoadingScenesComponent : IEcsAutoReset
    {
        public ISceneLoadingListConfig Config;
        
        public void Reset()
        {
            Config = null;
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component (as an event) is sent when a scene become active.
    /// </summary>
    public sealed class SceneActivatedComponent : IEcsAutoReset
    {
        public IAssetName SceneName;
        
        public void Reset()
        {
            SceneName = null;
        }
    }
}
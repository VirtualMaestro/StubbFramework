using Leopotam.Ecs;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component (as an event) is sent when a scene become inactive.
    /// </summary>
    public sealed class SceneDeactivatedComponent : IEcsAutoReset
    {
        public IAssetName SceneName;
        
        public void Reset()
        {
            SceneName = null;
        }
    }
}
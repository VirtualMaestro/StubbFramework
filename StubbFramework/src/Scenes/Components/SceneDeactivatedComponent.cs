using Leopotam.Ecs;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component (as an event) is sent when a scene become inactive (content of the scene).
    /// IMPORTANT: You will not get this component if scene was unload.
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
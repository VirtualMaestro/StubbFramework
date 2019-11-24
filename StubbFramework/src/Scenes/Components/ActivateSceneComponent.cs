using Leopotam.Ecs;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    public sealed class ActivateSceneComponent : IEcsOneFrame, IEcsAutoReset
    {
        public IAssetName Name;
        public bool Active;
        
        public void Reset()
        {
            Name = null;
            Active = false;
        }
    }
}
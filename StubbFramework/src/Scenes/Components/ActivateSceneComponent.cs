using Leopotam.Ecs;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    public sealed class ActivateSceneComponent : IEcsOneFrame, IEcsAutoReset
    {
        public IAssetName Name;
        public bool Active;
        public bool IsMain;
        
        public void Reset()
        {
            Name = null;
        }
    }
}
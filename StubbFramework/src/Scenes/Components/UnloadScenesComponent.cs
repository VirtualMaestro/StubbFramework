using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// If SceneNames is null will be unloaded all the scenes.
    /// </summary>
    public sealed class UnloadScenesComponent : IEcsAutoReset
    {
        public IList<IAssetName> SceneNames;
        
        public void Reset()
        {
            SceneNames = null;
        }
    }
}
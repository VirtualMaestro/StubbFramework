using System.Collections.Generic;
using Leopotam.Ecs;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes.Components
{
    /// <summary>
    /// Component contains list of progresses of scenes loading.
    /// </summary>
    public sealed class ActiveLoadingScenesComponent : IEcsAutoReset
    {
        public List<ISceneLoadingProgress> Progresses;
        public List<IAssetName> UnloadScenes;
        public bool UnloadOthers;
        
        public void Reset()
        {
            Progresses = null;
            UnloadScenes = null;
            UnloadOthers = false;
        }
    }
}
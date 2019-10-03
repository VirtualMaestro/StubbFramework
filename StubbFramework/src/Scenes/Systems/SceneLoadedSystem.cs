using Leopotam.Ecs;
using StubbFramework.Common;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
    public class SceneLoadedSystem : EcsSystem
    {
        EcsFilter<SceneComponent, NewEntityComponent> _newSceneFilter;
        EcsFilter<InternalActiveLoadingScenesComponent> _activeLoadingFilter;
        
        public override void Run()
        {
            if (_newSceneFilter.IsEmpty()) return;
            var activeLoading = _activeLoadingFilter.Get1[0];
            
            foreach (var idx in _newSceneFilter)
            {
                activeLoading.Config.Pop();
            }

            if (activeLoading.Config.IsEmpty)
            {
                _activeLoadingFilter.Entities[0].Destroy();
            }
        }
    }
}
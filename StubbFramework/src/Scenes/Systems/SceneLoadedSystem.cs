using Leopotam.Ecs;
using StubbFramework.Common;
using StubbFramework.Remove;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
    public class SceneLoadedSystem : EcsSystem
    {
        private EcsFilter<SceneComponent, NewEntityComponent> _newSceneFilter;
        private EcsFilter<InternalActiveLoadingScenesComponent> _activeLoadingFilter;
        
        public override void Initialize()
        {
            _newSceneFilter = World.GetFilter<EcsFilter<SceneComponent, NewEntityComponent>>();    
            _activeLoadingFilter = World.GetFilter<EcsFilter<InternalActiveLoadingScenesComponent>>();    
        }

        public override void Run()
        {
            if (_newSceneFilter.IsEmpty()) return;
            var activeLoading = _activeLoadingFilter.Components1[0];
            
            foreach (var idx in _newSceneFilter)
            {
                activeLoading.Config.Pop();
            }

            if (activeLoading.Config.IsEmpty)
            {
                World.AddComponent<RemoveEntityComponent>(_activeLoadingFilter.Entities[0]);
            }
        }

        public override void Destroy()
        {
            _newSceneFilter = null;
            _activeLoadingFilter = null;
        }
    }
}
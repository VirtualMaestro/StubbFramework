using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public class UnloadNonNewScenesSystem : EcsSystem
    {
        private EcsFilter<UnloadNonNewScenesComponent> _filter;
        private EcsFilter<SceneServiceComponent> _serviceFilter;
        private EcsFilter<SceneComponent>.Exclude<NewSceneMarkerComponent> _nonNewScenesFilter;
        
        public override void Run()
        {
            if (_filter.IsEmpty()) return;

            var sceneService = _serviceFilter.Single().SceneService;

            foreach (var idx in _nonNewScenesFilter)
            {
                sceneService.Unload(_nonNewScenesFilter.Get1[idx].Scene);
                _nonNewScenesFilter.Entities[idx].Destroy();
            }
        }
    }
}
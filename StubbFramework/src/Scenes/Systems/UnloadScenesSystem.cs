using Leopotam.Ecs;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public sealed class UnloadScenesSystem : EcsSystem
    {
        EcsFilter<UnloadScenesComponent> _unloadFilter;
        EcsFilter<SceneServiceComponent> _sceneServiceFilter;

        public override void Run()
        {
            if (_unloadFilter.IsEmpty()) return;

            var service = _sceneServiceFilter.Get1[0].SceneService;

            foreach (var idx in _unloadFilter)
            {
                service.Unload(_unloadFilter.Get1[idx].SceneNames);
                _unloadFilter.Entities[idx].Destroy();
            }
        }
    }
}
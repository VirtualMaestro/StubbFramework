using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Remove.Components;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class UnloadSceneSystem : IEcsRunSystem
    {
        private EcsFilter<SceneComponent, RemoveEntityComponent> _unloadScenesFilter;
        private EcsFilter<SceneServiceComponent> _serviceFilter;

        public void Run()
        {
            if (_unloadScenesFilter.IsEmpty()) return;

            var service = _serviceFilter.Single().SceneService;
            
            foreach (var idx in _unloadScenesFilter)
            {
                var controller = _unloadScenesFilter.Get1(idx).Scene;
                service.Unload(controller);
                controller.Destroy();
            }
        }
    }
}
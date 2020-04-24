using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Common.Components;
using StubbFramework.Extensions;
using StubbFramework.Remove.Components;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class LoadingScenesProgressSystem : IEcsRunSystem
    {
        private EcsWorld World;
        private EcsFilter<ActiveLoadingScenesComponent> _loadingFilter;
        private EcsFilter<SceneServiceComponent> _sceneServiceFilter;

        public void Run()
        {
            foreach (var idx in _loadingFilter)
            {
                var activeLoading = _loadingFilter.Get1(idx);

                if (!_IsEverySceneLoaded(activeLoading.Progresses)) continue;

                _ProcessScenes(activeLoading.Progresses);

                if (activeLoading.UnloadOthers)
                {
                    World.UnloadNonNewScenes();
                }
                else if (activeLoading.UnloadScenes != null)
                {
                    World.UnloadScenes(activeLoading.UnloadScenes);
                }

                _loadingFilter.GetEntity(idx).Set<RemoveEntityComponent>();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _ProcessScenes(List<ISceneLoadingProgress> progresses)
        {
            var service = _sceneServiceFilter.Single().SceneService;

            foreach (var progress in progresses)
            {
                var controller = service.GetLoadedSceneController(progress);
                _InitSceneController(controller, progress.Config);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _InitSceneController(ISceneController controller, ILoadingSceneConfig config)
        {
            var entity = World.NewEntity();
            entity.Set<SceneLoadedComponent>();

            ref var sceneComponent = ref entity.Set<SceneComponent>();
            sceneComponent.Scene = controller;
            controller.SetEntity(ref entity);

            if (controller.IsContentActive) entity.Set<IsActiveComponent>();
            else entity.Set<IsInactiveComponent>();

            if (config.IsActive) World.ActivateScene(controller, config.IsMain);
            else World.DeactivateScene(controller);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool _IsEverySceneLoaded(List<ISceneLoadingProgress> progresses)
        {
            foreach (var progress in progresses)
            {
                if (progress.IsComplete == false)
                    return false;
            }

            return true;
        }
    }
}
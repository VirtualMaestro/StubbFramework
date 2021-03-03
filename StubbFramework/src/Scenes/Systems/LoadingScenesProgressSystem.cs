using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
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
        private readonly EcsWorld World = null;
        private readonly EcsFilter<ActiveLoadingScenesComponent> _loadingFilter = null;
        private readonly EcsFilter<SceneServiceComponent> _sceneServiceFilter = null;

        public void Run()
        {
            if (_loadingFilter.IsEmpty()) return;
            
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

                _loadingFilter.GetEntity(idx).Get<RemoveEntityComponent>();
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
            entity.Get<SceneLoadedComponent>();

            ref var sceneComponent = ref entity.Get<SceneComponent>();
            sceneComponent.Scene = controller;
            controller.SetEntity(ref entity);

            if (config.IsActive)
            {
                entity.Get<IsSceneInactiveComponent>();
                World.ActivateScene(controller, config.IsMain);
            }
            else
            {
                entity.Get<IsSceneActiveComponent>();
                World.DeactivateScene(controller);
            }
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
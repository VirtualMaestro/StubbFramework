using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Remove.Components;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Systems
{
    public sealed class LoadingScenesProgressSystem : IEcsRunSystem
    {
        private EcsWorld World;
        private EcsFilter<ActiveLoadingScenesComponent> _loadingFilter;
        private EcsFilter<SceneServiceComponent> _sceneServiceFilter;
        
        public void Run()
        {
            foreach (var idx in _loadingFilter)
            {
                var activeLoading = _loadingFilter.Get1[idx];

                if (_ProcessScenes(activeLoading.Progresses))
                {
                    if (activeLoading.UnloadOthers)
                    {
                        World.UnloadNonNewScenes();
                    }
                    else if (activeLoading.UnloadScenes != null)
                    {
                        World.UnloadScenes(activeLoading.UnloadScenes);
                    }
                    
                    _loadingFilter.Entities[idx].Set<RemoveEntityComponent>();    
                }
            }    
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private bool _ProcessScenes(List<ISceneLoadingProgress> progresses)
        {
            if (!_IsEverySceneLoaded(progresses)) return false;
            
            var service = _sceneServiceFilter.Single().SceneService;
            KeyValuePair<ISceneController, ILoadingSceneConfig>[] controllers = service.LoadingComplete(progresses);

            for (var index = 0; index < controllers.Length; index++)
            {
                ref var pair = ref controllers[index];
                _InitSceneController(pair.Key, pair.Value);
            }

            return true;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private void _InitSceneController(ISceneController controller, ILoadingSceneConfig config)
        {
            var entity = World.NewEntityWith<SceneComponent, NewSceneMarkerComponent>(out var sceneComponent, out var newSceneMarkerComponent);
            sceneComponent.Scene = controller;
            controller.SetEntity(ref entity);

            if (config.IsActive) 
                World.ActivateScene(controller.SceneName, config.IsMain);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private bool _IsEverySceneLoaded(List<ISceneLoadingProgress> progresses)
        {
            foreach (var progress in progresses)
            {
                if (progress.IsComplete == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
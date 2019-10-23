using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Remove.Components;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Configurations;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public sealed class LoadingScenesProgressSystem : EcsSystem
    {
        EcsFilter<ActiveLoadingScenesComponent> _loadingFilter;
        EcsFilter<SceneServiceComponent> _sceneServiceFilter;
        
        public override void Run()
        {
            foreach (var idx in _loadingFilter)
            {
                var activeLoading = _loadingFilter.Get1[idx];

                bool activeLoadingComplete = _ProcessScenes(activeLoading.Progresses);

                if (activeLoadingComplete)
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
        private bool _ProcessScenes(IList<ISceneLoadingProgress> progresses)
        {
            if (!_IsEverySceneLoaded(progresses)) return false;
            
            var service = _sceneServiceFilter.Single().SceneService;
            KeyValuePair<ISceneController, ILoadingSceneConfig>[] controllers = service.LoadingComplete(progresses);

            for (var index = 0; index < controllers.Length; index++)
            {
                ref var pair = ref controllers[index];
                var controller = pair.Key;
                var config = pair.Value;
                var entity = World.NewEntityWith<SceneComponent>(out var sceneComponent);
                sceneComponent.Scene = controller;
                controller.SetEntity(ref entity);

                if (config.IsActive) controller.ShowContent();
                if (config.IsMain) controller.SetAsMain();
            }

            return true;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private bool _IsEverySceneLoaded(IList<ISceneLoadingProgress> progresses)
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
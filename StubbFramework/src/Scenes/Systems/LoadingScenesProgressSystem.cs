using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Remove;
using StubbFramework.Remove.Components;
using StubbFramework.Scenes.Components;
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

                bool activeLoadingComplete = activeLoading.IsActivatingAll ? 
                                        _ProcessAllScenes(activeLoading.Progresses) : 
                                        _ProcessEachScene(activeLoading.Progresses);

                if (activeLoadingComplete)
                {
                    if (activeLoading.UnloadScenes != null)
                    {
                        World.UnloadScenes(activeLoading.UnloadScenes);
                    }
                    
                    _loadingFilter.Entities[idx].Set<RemoveEntityComponent>();    
                }
            }    
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private bool _ProcessAllScenes(ISceneLoadingProgress[] progresses)
        {
            if (!_IsEverySceneLoaded(progresses)) return false;
            
            var service = _sceneServiceFilter.Get1[0].SceneService;
            service.Activate(progresses);

            return true;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private bool _ProcessEachScene(ISceneLoadingProgress[] progresses)
        {
            int completedCount = 0;
            
            for (int i = 0; i < progresses.Length; i++)
            {
                var loadingProgress = progresses[i];

                if (loadingProgress == null)
                {
                    completedCount++;
                    continue;
                }
                
                if (!loadingProgress.IsComplete) continue;
                
                var service = _sceneServiceFilter.Get1[0].SceneService;
                service.Activate(loadingProgress);

                progresses[i] = null;
                completedCount++;
            }

            return completedCount == progresses.Length;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private bool _IsEverySceneLoaded(ISceneLoadingProgress[] progresses)
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
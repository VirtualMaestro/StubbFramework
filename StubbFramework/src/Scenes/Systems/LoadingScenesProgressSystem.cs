using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;
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
        private bool _ProcessScenes(ISceneLoadingProgress[] progresses)
        {
            if (!_IsEverySceneLoaded(progresses)) return false;
            
            var service = _sceneServiceFilter.Single().SceneService;
            service.LoadingComplete(progresses);

            return true;
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
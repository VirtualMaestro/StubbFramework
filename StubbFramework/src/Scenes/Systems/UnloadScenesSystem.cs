using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Common.Components;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public sealed class UnloadScenesSystem : EcsSystem
    {
        EcsFilter<UnloadScenesComponent> _unloadFilter;
        EcsFilter<SceneServiceComponent> _sceneServiceFilter;
        EcsFilter<SceneComponent>.Exclude<NewEntityMarkerComponent> _nonNewScenesFilter;

        public override void Run()
        {
            if (_unloadFilter.IsEmpty()) return;

            foreach (var idx in _unloadFilter)
            {
                _UnloadScenes(_unloadFilter.Get1[idx].SceneNames);
                _unloadFilter.Entities[idx].Destroy();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _UnloadScenes(IList<ISceneName> names)
        {
            if (names == null)
            {
                // remove all non-new scenes    
                _UnloadAllOtherScenes();
            }
            else
            {
                foreach (ISceneName sceneName in names)
                {
                    if (_UnloadScene(sceneName) == false) 
                    {
                        // log warning
                    }
                }    
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _UnloadAllOtherScenes()
        {
            var service = _sceneServiceFilter.Get1[0].SceneService;
            
            foreach (var idx in _nonNewScenesFilter)
            {
                service.Unload(_nonNewScenesFilter.Get1[idx].Scene);
                _nonNewScenesFilter.Entities[idx].Destroy();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool _UnloadScene(ISceneName sceneName)
        {
            foreach (var idx in _nonNewScenesFilter)
            {
                var sceneController = _nonNewScenesFilter.Get1[idx].Scene;
                
                if (sceneController.SceneName.Equals(sceneName))
                {
                    var service = _sceneServiceFilter.Get1[0].SceneService;
                    service.Unload(sceneController);
                    _nonNewScenesFilter.Entities[idx].Destroy();
                    return true;
                }
            }

            return false;
        }
    }
}
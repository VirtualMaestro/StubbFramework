using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public sealed class UnloadScenesSystem : EcsSystem
    {
        EcsFilter<UnloadScenesComponent> _unloadFilter;
        EcsFilter<SceneServiceComponent> _sceneServiceFilter;
        EcsFilter<SceneComponent> _scenesFilter;

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
                _UnloadAllScenes();
            }
            else
            {
                _UnloadScenesByNames(names);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _UnloadAllScenes()
        {
            var service = _sceneServiceFilter.Single().SceneService;
            
            foreach (var idx in _scenesFilter)
            {
                service.Unload(_scenesFilter.Get1[idx].Scene);
                _scenesFilter.Entities[idx].Destroy();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _UnloadScenesByNames(IList<ISceneName> names)
        {
            foreach (ISceneName sceneName in names)
            {
                if (_UnloadScene(sceneName) == false) 
                {
                    // log warning - scene wasn't found
                }
            }    
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool _UnloadScene(ISceneName sceneName)
        {
            foreach (var idx in _scenesFilter)
            {
                var sceneController = _scenesFilter.Get1[idx].Scene;
                
                if (sceneController.SceneName.Equals(sceneName))
                {
                    var service = _sceneServiceFilter.Get1[0].SceneService;
                    service.Unload(sceneController);
                    _scenesFilter.Entities[idx].Destroy();
                    return true;
                }
            }

            return false;
        }
    }
}
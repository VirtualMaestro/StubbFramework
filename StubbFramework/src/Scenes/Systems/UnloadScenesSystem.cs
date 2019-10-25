using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;
using StubbUnity.Logging;

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
        private void _UnloadScenes(IList<IAssetName> names)
        {
            if (names == null)  _UnloadAllScenes();
            else _UnloadScenesByNames(names);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _UnloadAllScenes()
        {
            foreach (var idx in _scenesFilter)
            {
                _RemoveScene(idx);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _UnloadScenesByNames(IList<IAssetName> names)
        {
            foreach (IAssetName sceneName in names)
            {
                var entityIndex = _FindSceneEntityIndex(sceneName);
               
                if (entityIndex != -1)
                {
                    _RemoveScene(entityIndex);
                }
            }    
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int _FindSceneEntityIndex(IAssetName sceneName)
        {
            foreach (var idx in _scenesFilter)
            {
                var sceneController = _scenesFilter.Get1[idx].Scene;
                
                if (sceneController.SceneName.Equals(sceneName))
                {
                    return idx;
                }
            }
            
            log.Warn($"UnloadScenesSystem._FindSceneEntityIndex. Scene '{sceneName}' to unload wasn't found!");
            return -1;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _RemoveScene(int entityIndex)
        {
            ref var entity = ref _scenesFilter.Entities[entityIndex];
            ISceneController controller = entity.Get<SceneComponent>().Scene;
            _sceneServiceFilter.Single().SceneService.Unload(controller);
            controller.Destroy();
            entity.Destroy();
        }
    }
}
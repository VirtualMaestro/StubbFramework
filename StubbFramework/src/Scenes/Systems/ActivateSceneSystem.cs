using System.Diagnostics;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Common.Names;
using StubbFramework.Extensions;
using StubbFramework.Logging;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
    public sealed class ActivateSceneSystem : IEcsRunSystem
    {
        private EcsFilter<SceneActivatedComponent> _sceneActivatedFilter;
        private EcsFilter<SceneDeactivatedComponent> _sceneDeactivatedFilter;
        private EcsFilter<ActivateSceneComponent> _activateFilter;
        private EcsFilter<SceneComponent> _scenesFilter;
        private EcsWorld _world;

        public void Run()
        {
            _ClearSceneActiveStatusFilters();
            
            foreach (var idx in _activateFilter)
            {
                var activateComponent = _activateFilter.Get1[idx];
                ISceneController scene = _GetScene(activateComponent.Name);
                
                _Validate(activateComponent, scene);

                if (activateComponent.IsMain) scene.SetAsMain();
                if (activateComponent.Active == scene.IsContentActive) continue;

                if (activateComponent.Active) _ActivateScene(scene);
                else _DeactivateScene(scene);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _ClearSceneActiveStatusFilters()
        {
            if (!_sceneActivatedFilter.IsEmpty()) _sceneActivatedFilter.Clear();
            if (!_sceneDeactivatedFilter.IsEmpty()) _sceneDeactivatedFilter.Clear();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ISceneController _GetScene(IAssetName sceneName)
        {
            foreach (var idx in _scenesFilter)
            {
                ISceneController scene = _scenesFilter.Get1[idx].Scene;

                if (scene.SceneName.Equals(sceneName))
                {
                    return scene;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _ActivateScene(ISceneController scene)
        {
            scene.ShowContent();
            _world.NewEntityWith<SceneActivatedComponent>(out var sceneActivatedComponent);
            sceneActivatedComponent.SceneName = scene.SceneName;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _DeactivateScene(ISceneController scene)
        {
            scene.HideContent();
            _world.NewEntityWith<SceneDeactivatedComponent>(out var sceneDeactivatedComponent);
            sceneDeactivatedComponent.SceneName = scene.SceneName;
        }

        [Conditional("DEBUG")]
        private void _Validate(ActivateSceneComponent activateComponent, ISceneController scene)
        {
            if (scene == null) 
                log.Error($"Try to activate scene {activateComponent.Name}, but scene doesn't exist!");
  
            if (activateComponent.Active == scene.IsContentActive)
                log.Warn($"Try to perform (de)activation for the scene {activateComponent.Name}, but state of the scene is already: {activateComponent.Active} ");
        }
    }
}
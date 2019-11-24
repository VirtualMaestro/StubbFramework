using System.Diagnostics;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Common.Names;
using StubbFramework.Scenes.Components;
using StubbUnity.Logging;

namespace StubbFramework.Scenes.Systems
{
    public sealed class ActivateSceneSystem : EcsSystem
    {
        private EcsFilter<ActivateSceneComponent> _activateFilter;
        private EcsFilter<SceneComponent> _scenesFilter;

        public override void Run()
        {
            foreach (var idx in _activateFilter)
            {
                var activateComponent = _activateFilter.Get1[idx];
                ISceneController scene = _GetScene(activateComponent.Name);
                
                _Validate(activateComponent, scene);

                if (activateComponent.Active) scene.ShowContent();
                else scene.HideContent();
            }
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

        [Conditional("DEBUG")]
        private void _Validate(ActivateSceneComponent activateComponent, ISceneController scene)
        {
            if (scene == null) 
                log.Fatal($"Try to activate scene {activateComponent.Name}, but scene doesn't exist!");
  
            if (activateComponent.Active == scene.IsContentActive)
                log.Warn($"Try to perform (de)activation for the scene {activateComponent.Name}, but state of the scene is already: {activateComponent.Active} ");
        }
    }
}
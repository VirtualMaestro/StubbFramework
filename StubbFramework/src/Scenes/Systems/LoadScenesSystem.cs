﻿using Leopotam.Ecs;
using StubbFramework.Scenes.Components;
using StubbFramework.Services.Components;

namespace StubbFramework.Scenes.Systems
{
    public class LoadScenesSystem : EcsSystem
    {
        EcsFilter<LoadScenesComponent> _loadScenesFilter;
        EcsFilter<SceneServiceComponent> _sceneServiceFilter;
       
        public override void Run()
        {
            if (_loadScenesFilter.IsEmpty()) return;
            var sceneService = _sceneServiceFilter.Get1[0].SceneService;
            
            foreach (var idx in _loadScenesFilter)
            {
                ref var entity = ref _loadScenesFilter.Entities[idx];
                var loadScenes = entity.Get<LoadScenesComponent>();
                var unloadScenes = loadScenes.UnloadScenes;
                ISceneLoadingProgress[] progresses = sceneService.Load(loadScenes.Config);
                
                World.NewEntityWith<ActiveLoadingScenesComponent>(out var activeLoadingScenes);
                activeLoadingScenes.IsActivatingAll = loadScenes.Config.IsActivatingAll;
                activeLoadingScenes.Progresses = progresses;
                activeLoadingScenes.UnloadScenes = unloadScenes;
                
                entity.Destroy();
            }
        }
    }
}
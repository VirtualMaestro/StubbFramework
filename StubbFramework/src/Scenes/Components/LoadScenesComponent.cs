﻿using Leopotam.Ecs;
using StubbFramework.Scenes.Configurations;

namespace StubbFramework.Scenes.Components
{
    public class LoadScenesComponent : IEcsAutoResetComponent
    {
        public ISceneLoadingListConfig Config;
        public string[] UnloadScenes;
        
        public void Reset()
        {
            Config = null;
            UnloadScenes = null;
        }
    }
}
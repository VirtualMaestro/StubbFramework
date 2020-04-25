﻿using Leopotam.Ecs;
using StubbFramework.Extensions;

namespace StubbFramework
{
    public class EcsFeature : IEcsSystem
    {
        private bool _isEnable = true;

        internal EcsSystems Systems { get; private set; }
        internal EcsSystems Parent { set; private get; }

        public string Name { get; }
        public EcsWorld World { get; }

        public EcsFeature(EcsWorld world, string name = null)
        {
            World = world;
            Name = name ?? GetType().Name;

            _InitSystems();
        }

        private void _InitSystems()
        {
            Systems = new EcsSystems(World, $"{Name}Systems");    
            SetupSystems();
        }

        public bool Enable
        {
            get => _isEnable;
            set
            {
                if (_isEnable == value) return;

                _isEnable = value;

                var idx = Parent.GetNamedRunSystem(Name);
                Parent.SetRunSystemState(idx, _isEnable);
            }
        }

        protected void Add(IEcsSystem system)
        {
            if (system is EcsFeature feature) Systems.AddFeature(feature);
            else Systems.Add(system);
        }

        protected void Inject<T>(T data)
        {
            Systems.Inject<T>(data);
        }

        protected void OneFrame<T>() where T : struct
        {
            Systems.OneFrame<T>();
        }

        /// <summary>
        /// Method where all the systems should be created and added.
        /// </summary>
        protected virtual void SetupSystems()
        {}
    }
}
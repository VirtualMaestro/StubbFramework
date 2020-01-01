using Leopotam.Ecs;
using StubbFramework.Extensions;

namespace StubbFramework
{
    public class EcsFeature : IEcsSystem
    {
        private EcsSystems _systems;
        private bool _isEnable = true;

        internal EcsSystems Systems => _systems;

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
            _systems = new EcsSystems(World, $"{Name}_FeatureSystems");    
            SetupSystems();
        }

        public bool Enable
        {
            get => _isEnable;
            set
            {
                if (_isEnable == value) return;

                _isEnable = value;

                var idx = _systems.GetNamedRunSystem($"{_systems.Name}_FeatureSystems");
                _systems.SetRunSystemState(idx, _isEnable);
            }
        }

        protected void Add(IEcsSystem system)
        {
            if (system is EcsFeature feature) _systems.AddFeature(feature);
            else _systems.Add(system);
        }

        /// <summary>
        /// Method where all the systems should be created and added.
        /// </summary>
        protected virtual void SetupSystems()
        {}
    }
}
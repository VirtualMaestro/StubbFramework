using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;

namespace StubbFramework
{
    public class EcsFeature : IEcsSystem
    {
        private bool _isEnable;
        private EcsSystems _parentSystems;
        
        internal EcsSystems InternalSystems { get; private set; }
        
        public string Name { get; }
        public EcsWorld World { get; }

        public EcsFeature(EcsWorld world, string name = null, bool isEnable = true)
        {
            World = world;
            Name = name ?? GetType().Name;
            _isEnable = isEnable;
            
            _InitSystems();
        }
        
        internal EcsSystems Parent
        {
            set
            {
                _parentSystems = value;
                if (_isEnable == false)
                    _EnableSystems(InternalSystems.Name, _isEnable);
            }
            private get => _parentSystems;
        }

        public bool Enable
        {
            get => _isEnable;
            set
            {
                if (_isEnable == value) return;

                _isEnable = value;

                _EnableSystems(InternalSystems.Name, _isEnable);
            }
        }

        protected void Add(IEcsSystem system)
        {
            if (system is EcsFeature feature) InternalSystems.AddFeature(feature);
            else InternalSystems.Add(system);
        }

        protected void Inject(object data)
        {
            InternalSystems.Inject(data);
        }

        protected void OneFrame<T>() where T : struct
        {
            InternalSystems.OneFrame<T>();
        }

        /// <summary>
        /// Method where all the systems should be created and added.
        /// </summary>
        protected virtual void SetupSystems()
        {}
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _InitSystems()
        {
            InternalSystems = new EcsSystems(World, $"{Name}Systems");    
            SetupSystems();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _EnableSystems(string systemsName, bool isEnable)
        {
            var idx = Parent.GetNamedRunSystem(systemsName);
            Parent.SetRunSystemState(idx, isEnable);
        }
    }
}
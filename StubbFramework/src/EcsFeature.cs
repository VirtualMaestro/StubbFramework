using System;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class EcsFeature : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem, IDisposable
    {
        private EcsSystems _systems;

        internal EcsSystems Systems => _systems;

        public EcsFeature(EcsWorld world, string name = null)
        {
            World = world;
            _systems = new EcsSystems(World, name);    
            SetupSystems();
        }

        public EcsWorld World { get; }

        public string Name
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => _systems.Name;
        }

        public virtual bool CanRun
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => true;
        }

        /// <summary>
        /// Method where all the systems should be created and added.
        /// </summary>
        protected virtual void SetupSystems()
        {}

        public void Add(IEcsSystem system)
        {
            _systems.Add(system);
        }
        
        public void Init()
        {
            _systems.Init();
        }

        public void Run()
        {
            if (CanRun)
            {
                _systems.Run();
            }
        }

        public void Destroy()
        {
           Dispose();
        }

        public void Dispose()
        {
            _systems.Destroy();
            _systems = null;
        }
    }
}
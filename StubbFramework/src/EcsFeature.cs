using System;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class EcsFeature : EcsSystem, IDisposable
    {
        private EcsSystems _systems;
        
        public EcsFeature(string name = null)
        {
            _systems = new EcsSystems(Stubb.World, name);    
            SetupSystems();
        }

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
        
        public override void Init()
        {
            _systems.Init();
        }

        public override void Run()
        {
            if (CanRun)
            {
                _systems.Run();
            }
        }

        public override void Destroy()
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
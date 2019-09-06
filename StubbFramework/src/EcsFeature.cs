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
            _systems = new EcsSystems(Stubb.Instance.World, name);    
        }

        protected string Name
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => _systems.Name;
        }

        public virtual bool CanRun
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => true;
        }

        public void Add(IEcsSystem system)
        {
            _systems.Add(system);
        }
        
        public override void Initialize()
        {
            _systems.Initialize();
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
            _systems.Dispose();
            _systems = null;
        }
    }
}
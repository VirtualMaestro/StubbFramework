using System;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class Feature : IDisposable, IEcsInitSystem, IEcsRunSystem
    {
        private EcsSystems _systems;
        
        public Feature(string name = null)
        {
            _systems = new EcsSystems(Stubb.Instance.World, name);    
        }

        public EcsWorld World => Stubb.Instance.World;
        public string Name => _systems.Name;
        public bool CanRun => true;
        
        public void Initialize()
        {
            _systems.Initialize();
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
            _systems.Dispose();
            _systems = null;
        }
    }
}
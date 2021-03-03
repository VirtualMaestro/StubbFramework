using Leopotam.Ecs;
using StubbFramework.Debugging;

namespace StubbFramework.Core
{
    public class StubbContext : IStubbContext
    {
        private EcsWorld _world;
        private IEcsDebug _debugger;
        
        protected EcsSystems RootSystems;

        public EcsFeature HeadFeature { get; set; }
        public EcsFeature MainFeature { get; set; }
        public EcsFeature TailFeature { get; set; }

        public bool IsDisposed => _world == null;
        public EcsWorld World => _world;

        public StubbContext() : this(new EcsWorld())
        { }

        public StubbContext(IEcsDebug debug) : this(new EcsWorld(), debug)
        { }

        public StubbContext(EcsWorld world, IEcsDebug debug = null)
        {
            Stubb.AddContext(this);
            
            _world = world;
            _debugger = debug;
            RootSystems = new EcsSystems(_world,  $"{GetType()}Systems");
            
            InitFeatures();
        }

        protected virtual void InitFeatures()
        {
            HeadFeature = new SystemHeadFeature(World);
            TailFeature = new SystemTailFeature(World);
        }

        public void Init()
        {
            HeadFeature?.Init(RootSystems);
            MainFeature?.Init(RootSystems);
            TailFeature?.Init(RootSystems);

            _debugger?.Init(RootSystems, World);

            RootSystems.ProcessInjects();
            RootSystems.Init();
        }

        public void Run()
        {
            RootSystems.Run();
            _debugger?.Debug();
        }

        public virtual void Dispose()
        {
            RootSystems.Destroy();
            RootSystems = null;
            _debugger = null;
            
            if (_world != null && _world.IsAlive())
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}
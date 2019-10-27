using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class StubbContextDefault : IStubbContext
    {
        private EcsWorld _world;
        private EcsSystems _rootSystems;

        public bool IsDisposed => _world == null;
        public IStubbDebug DebugInfo { get; private set; }

        public void Init()
        {
            Init(new EcsWorld(), null);
        }

        public void Init(EcsWorld world)
        {
            Init(world, null);
        }

        public void Init(IStubbDebug debug)
        {
            Init(new EcsWorld(), debug);
        }
        
        public void Init(EcsWorld world, IStubbDebug debug)
        {
            _world = world;
            DebugInfo = debug;
            
            _rootSystems = InitSystems();
            
            DebugInfo?.Debug(_rootSystems, _world);

            _rootSystems.ProcessInjects();
            _rootSystems.Init();
            
            Stubb.AddContext(this);
        }
        
        protected virtual EcsSystems InitSystems()
        {
            var rootSystems = new EcsSystems(World, "RootSystems");
            rootSystems.Add(new SystemHeadFeature(World));
            rootSystems.Add(InitUserSystems());
            rootSystems.Add(new SystemTailFeature(World));

            return rootSystems;
        }

        protected virtual IEcsSystem InitUserSystems()
        {
            return new EcsSystems(World, "UserSystems");
        }

        public EcsWorld World
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => _world;
        }
        
        public void Run()
        {
            _rootSystems.Run();
            _world.EndFrame();
        }

        public void Dispose()
        {
            _rootSystems.Destroy();
            _world.Destroy();

            _world = null;
            _rootSystems = null;
        }
    }
}
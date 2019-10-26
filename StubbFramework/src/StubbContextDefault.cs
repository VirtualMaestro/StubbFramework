using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class StubbContextDefault : IStubbContext
    {
        private EcsWorld _world;
        private EcsSystems _rootSystems;
        private EcsSystems _userSystems;

        public bool IsDisposed => _world == null;
        public IStubbDebug DebugInfo { get; private set; }
        
        public void Init(EcsWorld world = null, IStubbDebug debug = null)
        {
            _world = world ?? new EcsWorld();
            DebugInfo = debug;
            
            _rootSystems = new EcsSystems(_world, "SystemsRoot");
            _userSystems = new EcsSystems(_world, "SystemsUserBody");
            
            _rootSystems.Add(new SystemHeadFeature());
            _rootSystems.Add(_userSystems);
            _rootSystems.Add(new SystemTailFeature());
        }

        public EcsWorld World
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => _world;
        }
        
        public void Add(IEcsSystem ecsSystem)
        {
            _userSystems.Add(ecsSystem);
        }

        public void InitSystems()
        {
            DebugInfo?.Debug(_rootSystems, _world);

            _rootSystems.ProcessInjects();
            _rootSystems.Init();
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
            _userSystems = null;
        }
    }
}
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Extensions;

namespace StubbFramework
{
    public class StubbContextDefault : IStubbContext
    {
        private EcsWorld _world;
        private EcsSystems _rootSystems;
        private IStubbDebug _debugInfo;

        public bool IsDisposed => _world == null;

        public void Init(EcsWorld world, IStubbDebug debug = null)
        {
            Stubb.AddContext(this);

            _world = world;
            _debugInfo = debug;

            _rootSystems = InitSystems();
            
            _debugInfo?.Debug(_rootSystems, _world);

            _rootSystems.ProcessInjects();
            _rootSystems.Init();
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
            _world.EndCollisionFrame();
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
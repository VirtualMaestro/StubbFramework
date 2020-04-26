using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Debugging;
using StubbFramework.Extensions;

namespace StubbFramework
{
    public class StubbContextDefault : IStubbContext
    {
        private EcsWorld _world;
        private EcsSystems _rootSystems;
        private IStubbDebug _debugger;

        public bool IsDisposed => _world == null;

        public void Init(EcsWorld world, IStubbDebug debug = null)
        {
            Stubb.AddContext(this);

            _world = world;
            _debugger = debug;

            _rootSystems = InitSystems();

            _debugger?.Init(_rootSystems, _world);

            _rootSystems.ProcessInjects();
            _rootSystems.Init();
        }

        protected virtual EcsSystems InitSystems()
        {
            var rootSystems = new EcsSystems(World, "RootSystems");
            rootSystems.AddFeature(new SystemHeadFeature(World));

            var userSystems = InitUserSystems();
            if (userSystems is EcsFeature feature) rootSystems.AddFeature(feature);
            else rootSystems.Add(userSystems);

            rootSystems.AddFeature(new SystemTailFeature(World));

            return rootSystems;
        }

        protected virtual IEcsSystem InitUserSystems()
        {
            return new EcsSystems(World, "UserSystems");
        }

        public EcsWorld World
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _world;
        }

        public void Run()
        {
            _rootSystems.Run();
            _debugger?.Debug();
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
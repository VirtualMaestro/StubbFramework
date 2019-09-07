using System;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class Stubb
    {
        private static readonly Lazy<Stubb> _lazy = new Lazy<Stubb>(() => new Stubb());
        public static Stubb Instance => _lazy.Value;

        private EcsWorld _world;
        private EcsSystems _rootSystems;
        private EcsSystems _userSystems;

        private Stubb()
        {
            _world = new EcsWorld();
            _rootSystems = new EcsSystems(_world, "SystemsRoot");
            _userSystems = new EcsSystems(_world, "SystemsBody");

            _rootSystems.Add(SystemsHeadConfig.Create(_world));
            _rootSystems.Add(_userSystems);
            _rootSystems.Add(SystemsTailConfig.Create(_world));
        }

        public EcsWorld World
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => _world;
        }

        public void Add(EcsFeature ecsFeature)
        {
            _userSystems.Add(ecsFeature);
        }

        public void Initialize(IStubbDebug debug = null)
        {
            debug?.Debug(_rootSystems, _world);

            _rootSystems.Initialize();
        }

        public void Update()
        {
            _rootSystems.Run();
            _world.RemoveOneFrameComponents ();
        }

        public void Dispose()
        {
            _rootSystems.Dispose();
            _world.Dispose();

            _world = null;
            _rootSystems = null;
            _userSystems = null;
        }
    }
}
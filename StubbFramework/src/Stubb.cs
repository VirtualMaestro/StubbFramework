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
        private EcsSystems _systemsHead;
        private EcsSystems _systemsBody;
        private EcsSystems _systemsTail;

        private Stubb()
        {
            _world = new EcsWorld();
            _systemsHead = SystemsHeadConfig.Create(_world);
            _systemsBody = new EcsSystems(_world, "SystemsBody");
            _systemsTail = SystemsTailConfig.Create(_world);
        }

        public EcsWorld World
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => _world;
        }

        public void Add(EcsFeature ecsFeature)
        {
            _systemsBody.Add(ecsFeature);
        }

        public void Initialize()
        {
            _systemsHead.Initialize();
            _systemsBody.Initialize();
            _systemsTail.Initialize();
        }

        public void Update()
        {
            _systemsHead.Run();
            _systemsBody.Run();
            _systemsTail.Run();
        }

        public void Dispose()
        {
            _systemsHead.Dispose();
            _systemsBody.Dispose();
            _systemsTail.Dispose();
            _world.Dispose();

            _world = null;
            _systemsHead = null;
            _systemsBody = null;
            _systemsTail = null;
        }
    }
}
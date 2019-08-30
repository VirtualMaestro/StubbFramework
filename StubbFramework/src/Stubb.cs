using System;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class Stubb
    {
        private static readonly Lazy<Stubb> _lazy = new Lazy<Stubb>(() => new Stubb());

        public static Stubb Instance => _lazy.Value;

        private EcsWorld _world;
        private readonly EcsSystems _systemsHead;
        private readonly EcsSystems _systemsBody;
        private readonly EcsSystems _systemsTail;

        private Stubb()
        {
            _world = new EcsWorld();
            _systemsHead = SystemsHeadConfig.Create(_world);
            _systemsBody = new EcsSystems(_world, "SystemsBody");
            _systemsTail = SystemsTailConfig.Create(_world);
        }

        public void AddSystem(IEcsSystem system, bool init = false)
        {
            _systemsBody.Add(system);

            if (init && (system is IEcsInitSystem initSystem))
            {
                initSystem.Initialize();
            }
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
        }
    }
}
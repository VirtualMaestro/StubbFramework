using Leopotam.Ecs;

namespace StubbFramework
{
    public interface IStubbContext
    {
        EcsWorld World { get; }

        void Create();
        void Add(EcsSystem ecsSystem);
        void Initialize();
        void Update();
        void Dispose();

        IStubbDebug DebugInfo { get; set; }
    }
}
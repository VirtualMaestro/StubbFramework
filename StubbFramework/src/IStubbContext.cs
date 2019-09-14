using Leopotam.Ecs;

namespace StubbFramework
{
    public interface IStubbContext
    {
        EcsWorld World { get; }

        void Add(EcsSystems ecsSystems);
        void Initialize();
        void Update();
        void Dispose();

        IStubbDebug DebugInfo { get; set; }
    }
}
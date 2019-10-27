using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework
{
    public interface IStubbContext : IDispose
    {
        EcsWorld World { get; }

        void Init();
        void Init(EcsWorld world);
        void Init(IStubbDebug debug);
        void Init(EcsWorld world, IStubbDebug debug);
        void Run();

        IStubbDebug DebugInfo { get; }
    }
}
using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework
{
    public interface IStubbContext : IDispose
    {
        EcsWorld World { get; }

        void Init(EcsWorld world = null, IStubbDebug debug = null);
        void Run();

        IStubbDebug DebugInfo { get; }
    }
}
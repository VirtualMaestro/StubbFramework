using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework
{
    public interface IStubbContext : IDispose
    {
        EcsWorld World { get; }

        void Init(EcsWorld world, IStubbDebug debug = null);
        void Run();
    }
}
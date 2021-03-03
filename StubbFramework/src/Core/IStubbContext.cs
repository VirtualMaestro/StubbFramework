using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework.Core
{
    public interface IStubbContext : IDispose
    {
        EcsWorld World { get; }

        void Init();
        void Run();

        EcsFeature HeadFeature { get; set; }
        EcsFeature MainFeature { get; set; }
        EcsFeature TailFeature { get; set; }
    }
}
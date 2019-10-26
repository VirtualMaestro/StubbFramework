using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework
{
    public interface IStubbContext : IDispose
    {
        EcsWorld World { get; }

        void Init(EcsWorld world = null, IStubbDebug debug = null);
        /// <summary>
        /// Method where user has to be able to add his systems.
        /// </summary>
        /// <param name="ecsSystem"></param>
        void Add(IEcsSystem ecsSystem);
        void InitSystems();
        void Run();

        IStubbDebug DebugInfo { get; }
    }
}
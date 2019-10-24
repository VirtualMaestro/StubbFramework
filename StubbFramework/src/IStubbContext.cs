using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework
{
    public interface IStubbContext : IDispose
    {
        EcsWorld World { get; }

        void Create();
        /// <summary>
        /// Method where user has to be able to add his systems.
        /// </summary>
        /// <param name="ecsSystem"></param>
        void Add(IEcsSystem ecsSystem);
        void Initialize();
        void Run();

        IStubbDebug DebugInfo { get; set; }
    }
}
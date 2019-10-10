using Leopotam.Ecs;

namespace StubbFramework
{
    public interface IStubbContext
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
        void Dispose();

        IStubbDebug DebugInfo { get; set; }
    }
}
using Leopotam.Ecs;

namespace StubbFramework.Debugging
{
    public interface IStubbDebug
    {
        void Init(EcsSystems rootSystems, EcsWorld world);
        /// <summary>
        /// Supposed to be called every frame.
        /// </summary>
        void Debug();
    }
}
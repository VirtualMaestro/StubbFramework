using Leopotam.Ecs;

namespace StubbFramework
{
    internal static class SystemsHeadConfig
    {
        internal static EcsSystems Create(EcsWorld world)
        {
            var headSystems = new EcsSystems(world, "SystemsHead");
            
            

            return headSystems;
        }
    }
}
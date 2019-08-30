using Leopotam.Ecs;

namespace StubbFramework
{
    public static class SystemsHeadConfig
    {
        public static EcsSystems Create(EcsWorld world)
        {
            var headSystems = new EcsSystems(world, "SystemsHead");
            
            

            return headSystems;
        }
    }
}
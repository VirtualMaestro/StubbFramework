using Leopotam.Ecs;

namespace StubbFramework
{
    public static class SystemsTailConfig
    {
        public static EcsSystems Create(EcsWorld world)
        {
            var tailSystems = new EcsSystems(world, "SystemsTail");
            
            

            return tailSystems;
        }
    }
}
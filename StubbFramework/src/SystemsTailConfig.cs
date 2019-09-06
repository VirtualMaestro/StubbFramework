using Leopotam.Ecs;

namespace StubbFramework
{
    internal static class SystemsTailConfig
    {
        internal static EcsSystems Create(EcsWorld world)
        {
            var tailSystems = new EcsSystems(world, "SystemsTail");
            
            

            return tailSystems;
        }
    }
}
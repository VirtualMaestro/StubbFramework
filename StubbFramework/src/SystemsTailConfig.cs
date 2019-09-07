using Leopotam.Ecs;
using StubbFramework.Remove;

namespace StubbFramework
{
    internal static class SystemsTailConfig
    {
        internal static EcsSystems Create(EcsWorld world)
        {
            var tailSystems = new EcsSystems(world, "SystemsTail");
            
            tailSystems.Add(new RemoveEntitySystem());

            return tailSystems;
        }
    }
}
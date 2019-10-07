using Leopotam.Ecs;
using StubbFramework.Remove;
using StubbFramework.Scenes.Systems;

namespace StubbFramework
{
    internal static class SystemsTailConfig
    {
        internal static EcsSystems Create(EcsWorld world)
        {
            var tailSystems = new EcsSystems(world, "SystemsTail");
            
            tailSystems.Add(new UnloadScenesSystem());
            tailSystems.Add(new RemoveEntitySystem());

            return tailSystems;
        }
    }
}
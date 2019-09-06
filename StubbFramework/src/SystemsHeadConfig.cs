using Leopotam.Ecs;
using StubbFramework.Remove;
using StubbFramework.Time;

namespace StubbFramework
{
    internal static class SystemsHeadConfig
    {
        internal static EcsSystems Create(EcsWorld world)
        {
            var headSystems = new EcsSystems(world, "SystemsHead");

            headSystems.Add(new RemoveEntitySystem());
            headSystems.Add(new TimeSystem());

            return headSystems;
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Delay;
using StubbFramework.Scenes.Systems;
using StubbFramework.Time;

namespace StubbFramework
{
    internal static class SystemsHeadConfig
    {
        internal static EcsSystems Create(EcsWorld world)
        {
            var headSystems = new EcsSystems(world, "SystemsHead");

            headSystems.Add(new TimeSystem());
            headSystems.Add(new DelaySystem());
            headSystems.Add(new LoadScenesSystem());

            return headSystems;
        }
    }
}
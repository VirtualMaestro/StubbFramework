using Leopotam.Ecs;
using StubbFramework.Time;

namespace StubbFramework
{
    internal static class SystemsHeadConfig
    {
        internal static EcsSystems Create()
        {
            var headSystems = new EcsSystems(Stubb.Instance.World, "SystemsHead");

            headSystems.Add(new TimeSystem());

            return headSystems;
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Delay.Systems;
using StubbFramework.Time.Systems;

namespace StubbFramework.Core
{
    public class SystemHeadFeature : EcsFeature
    {
        public SystemHeadFeature(EcsWorld world, string name = "HeadSystems") : base(world, name)
        {
            Add(new TimeSystem());
            Add(new DelaySystem());
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Delay.Systems;
using StubbFramework.Scenes.Systems;
using StubbFramework.Time.Systems;

namespace StubbFramework
{
    public class SystemHeadFeature : EcsFeature
    {
        public SystemHeadFeature(EcsWorld world, string name = null) : base(world, name ?? "HeadSystems")
        {}

        protected override void SetupSystems()
        {
            Add(new TimeSystem());
            Add(new DelaySystem());
            Add(new LoadScenesSystem());
            Add(new LoadingScenesProgressSystem());
        }
    }
}
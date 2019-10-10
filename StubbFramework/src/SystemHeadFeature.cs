using StubbFramework.Delay;
using StubbFramework.Delay.Systems;
using StubbFramework.Scenes.Systems;
using StubbFramework.Time;
using StubbFramework.Time.Systems;

namespace StubbFramework
{
    public class SystemHeadFeature : EcsFeature
    {
        public SystemHeadFeature() : base("SystemHead")
        {
            Add(new TimeSystem());
            Add(new DelaySystem());
            Add(new LoadScenesSystem());
            Add(new LoadingScenesProgressSystem());
        }
    }
}
using StubbFramework.Delay;
using StubbFramework.Scenes.Systems;
using StubbFramework.Time;

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
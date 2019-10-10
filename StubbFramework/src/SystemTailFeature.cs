using StubbFramework.Remove;
using StubbFramework.Remove.Systems;
using StubbFramework.Scenes.Systems;

namespace StubbFramework
{
    public class SystemTailFeature : EcsFeature
    {
        public SystemTailFeature() : base("SystemTail")
        {
            Add(new UnloadScenesSystem());
            Add(new RemoveEntitySystem());
        }
    }
}
using StubbFramework.Remove;
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
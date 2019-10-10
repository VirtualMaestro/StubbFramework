using StubbFramework.Remove.Systems;
using StubbFramework.Scenes.Systems;

namespace StubbFramework
{
    public class SystemTailFeature : EcsFeature
    {
        public SystemTailFeature() : base("TailSystems")
        {
            Add(new UnloadScenesSystem());
            Add(new RemoveEntitySystem());
        }
    }
}
using StubbFramework.Remove.Systems;
using StubbFramework.Scenes.Systems;

namespace StubbFramework
{
    public class SystemTailFeature : EcsFeature
    {
        public SystemTailFeature() : base("TailSystems")
        {}

        protected override void SetupSystems()
        {
            Add(new UnloadScenesSystem());
            Add(new UnloadNonNewScenesSystem());
            Add(new RemoveEntitySystem());
        }
    }
}
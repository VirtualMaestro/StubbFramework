using Leopotam.Ecs;
using StubbFramework.Remove.Systems;
using StubbFramework.Scenes;
using StubbFramework.View.Systems;

namespace StubbFramework.Core
{
    public class SystemTailFeature : EcsFeature
    {
        public SystemTailFeature(EcsWorld world, string name = "TailSystems") : base(world, name)
        {
            Add(new SceneFeature(World));
            Add(new RemoveEcsViewLinkSystem());
            Add(new RemoveEntitySystem());
        }
    }
}
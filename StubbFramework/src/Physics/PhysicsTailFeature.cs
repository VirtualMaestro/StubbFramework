using Leopotam.Ecs;
using StubbFramework.Core;
using StubbFramework.Physics.Systems;

namespace StubbFramework.Physics
{
    public class PhysicsTailFeature : EcsFeature
    {
        public PhysicsTailFeature(EcsWorld world, string name = null, bool isEnable = true) : base(world, name, isEnable)
        {
            Add(new CleanupCollisionSystem());
        }
    }
}
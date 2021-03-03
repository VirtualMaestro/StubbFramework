using Leopotam.Ecs;
using StubbFramework.Core;

namespace StubbFramework.Physics
{
    public class PhysicsContext : StubbContext, IPhysicsContext
    {
        public PhysicsContext(EcsWorld world) : base(world)
        {
        }

        protected override void InitFeatures()
        {
            TailFeature = new PhysicsTailFeature(World);
        }

        public override void Dispose()
        {
            RootSystems.Destroy();
            RootSystems = null;
        }
    }
}
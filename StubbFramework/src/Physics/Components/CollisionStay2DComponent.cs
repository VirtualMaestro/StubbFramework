using Leopotam.Ecs;

namespace StubbFramework.Physics.Components
{
    public sealed class CollisionStay2DComponent : IEcsAutoReset
    {
        public IViewPhysics ObjectA;
        public IViewPhysics ObjectB;
        public object Info;
        
        public void Reset()
        {
            ObjectA = null;
            ObjectB = null;
            Info = null;
        }
    }
}
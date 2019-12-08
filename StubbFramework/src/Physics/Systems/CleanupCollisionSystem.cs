using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Physics.Components;

namespace StubbFramework.Physics.Systems
{
    public sealed class CleanupCollisionSystem : IEcsRunSystem
    {
        private EcsWorld World;
        private EcsFilter<CleanupCollisionComponent> _cleanupCollisionFilter;
        
        public void Run()
        {
            foreach (var idx in _cleanupCollisionFilter)
            {
                _cleanupCollisionFilter.Entities[idx].Destroy();
            }
            
            World.EndPhysicsFrame();
        }
    }
}
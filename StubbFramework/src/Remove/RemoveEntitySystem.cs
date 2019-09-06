using Leopotam.Ecs;

namespace StubbFramework.Remove
{
    public sealed class RemoveEntitySystem : EcsSystem
    {
        private EcsFilter<RemoveEntityComponent> _filter;
        
        public override void Initialize()
        {
            _filter = World.GetFilter<EcsFilter<RemoveEntityComponent>>();
        }

        public override void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.Entities[index];
                World.RemoveEntity(entity);
            }
        }
    }
}
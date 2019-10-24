using Leopotam.Ecs;
using StubbFramework.Delay.Components;
using StubbFramework.Remove.Components;

namespace StubbFramework.Remove.Systems
{
    public sealed class RemoveEntitySystem : EcsSystem
    {
        EcsFilter<RemoveEntityComponent>.Exclude<DelayComponent> _removeFilter;
        
        public override void Run()
        {
            foreach (var index in _removeFilter)
            {
                _removeFilter.Entities[index].Destroy();
            }
        }
    }
}
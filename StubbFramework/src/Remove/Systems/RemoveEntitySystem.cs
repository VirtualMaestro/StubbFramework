using Leopotam.Ecs;
using StubbFramework.Delay.Components;
using StubbFramework.Remove.Components;

namespace StubbFramework.Remove.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class RemoveEntitySystem : IEcsRunSystem
    {
        EcsFilter<RemoveEntityComponent>.Exclude<DelayComponent> _removeFilter;

        public void Run()
        {
            foreach (var index in _removeFilter)
            {
                _removeFilter.GetEntity(index).Destroy();
            }
        }
    }
}
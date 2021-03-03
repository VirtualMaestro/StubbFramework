using Leopotam.Ecs;
using StubbFramework.Delay.Components;
using StubbFramework.Remove.Components;
using StubbFramework.View.Components;

namespace StubbFramework.View.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class RemoveEcsViewLinkSystem : IEcsRunSystem
    {
        private EcsFilter<EcsViewLinkComponent, RemoveEntityComponent>.Exclude<DelayComponent> _removeViewFilter;
            
        public void Run()
        {
            if (_removeViewFilter.IsEmpty()) return;
            
            foreach (var idx in _removeViewFilter)
            {
                var view = _removeViewFilter.Get1(idx).Value;
                view.Dispose();
            }
        }
    }
}
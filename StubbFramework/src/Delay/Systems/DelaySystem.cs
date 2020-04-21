using Leopotam.Ecs;
using StubbFramework.Delay.Components;
using StubbFramework.Extensions;
using StubbFramework.Time.Components;

namespace StubbFramework.Delay.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class DelaySystem : IEcsRunSystem
    {
        private EcsFilter<DelayComponent> _filterDelay;
        private EcsFilter<TimeComponent> _filterTime;

        public void Run()
        {
            if (_filterDelay.IsEmpty()) return;
            
            var time = _filterTime.Single();

            foreach (var index in _filterDelay)
            {
                var delay = _filterDelay.Get1(index);
                delay.Frames--;
                delay.Milliseconds -= time.TimeStep;

                if (delay.Frames <= 0 && delay.Milliseconds <= 0)
                {
                    _filterDelay.GetEntity(index).Unset<DelayComponent>();
                }
            }
        }
    }
}
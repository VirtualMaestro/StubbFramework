using Leopotam.Ecs;
using StubbFramework.Extensions;
using StubbFramework.Scenes.Components;

namespace StubbFramework.Scenes.Systems
{
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public sealed class UnloadAllScenesSystem : IEcsRunSystem
    {
        private EcsFilter<UnloadAllScenesEvent> _eventFilter;
        private EcsFilter<SceneComponent> _scenesFilter;

        public void Run()
        {
            if (_eventFilter.IsEmpty()) return;

            _scenesFilter.MarkRemove();
        }
    }
}
using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class EcsSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        protected EcsWorld World
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => Stubb.World;
        }
        
        public virtual void Init()
        {
        }

        public virtual void Run()
        {
        }

        public virtual void Destroy()
        {
        }
     }
}
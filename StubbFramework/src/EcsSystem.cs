using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class EcsSystem : IEcsInitSystem, IEcsRunSystem
    {
        protected EcsWorld World
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => Stubb.Instance.World;
        }
        public virtual void Initialize()
        {
            
        }

        public virtual void Destroy()
        {
        }

        public virtual void Run()
        {
            
        }
    }
}
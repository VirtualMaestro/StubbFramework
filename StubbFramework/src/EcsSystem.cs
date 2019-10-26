using Leopotam.Ecs;

namespace StubbFramework
{
    public class EcsSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        protected EcsWorld World;
        
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
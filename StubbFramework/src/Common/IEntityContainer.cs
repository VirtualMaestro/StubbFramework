using Leopotam.Ecs;

namespace StubbFramework.Common
{
    public interface IEntityContainer
    {
        ref EcsEntity GetEntity();
        void SetEntity(ref EcsEntity entity);
        bool HasEntity { get; }
    }
}
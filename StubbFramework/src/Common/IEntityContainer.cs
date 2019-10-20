using Leopotam.Ecs;

namespace StubbFramework.Common
{
    public interface IEntityContainer
    {
        EcsEntity Entity { ref get; ref set; }
    }
}
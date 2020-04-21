using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework.View
{
    public interface IEcsViewLink : IEntityContainer, IDispose
    {
        string Name { get; }
        /// <summary>
        /// An instance of the World where this IEcsViewLink belongs to.
        /// </summary>
        EcsWorld World { get; }
    }
}
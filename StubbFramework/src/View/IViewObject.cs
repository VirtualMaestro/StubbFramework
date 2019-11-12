using Leopotam.Ecs;
using StubbFramework.Common;

namespace StubbFramework.View
{
    public interface IViewObject : IEntityContainer, IDispose
    {
        string Name { get; }
        /// <summary>
        /// An instance of the World where this IViewObject belongs to.
        /// </summary>
        EcsWorld World { get; }
    }
}
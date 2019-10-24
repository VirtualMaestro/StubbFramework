using StubbFramework.Common;

namespace StubbFramework.View
{
    public interface IViewObject : IEntityContainer, IDispose
    {
        string Name { get; }
    }
}
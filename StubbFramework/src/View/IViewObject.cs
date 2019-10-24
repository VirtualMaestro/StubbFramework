using StubbFramework.Common;

namespace StubbFramework.View
{
    public interface IViewObject : IEntityContainer, IDisposable
    {
        string Name { get; }
    }
}
using StubbFramework.Common;

namespace StubbFramework.View
{
    public interface IViewObject : IEntityContainer
    {
        string Name { get; }
        void Dispose();
        bool IsDisposed { get; }
    }
}
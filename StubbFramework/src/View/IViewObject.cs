using Leopotam.Ecs;

namespace StubbFramework.View
{
    public interface IViewObject
    {
        string Name { get; }
        EcsEntity Entity { get; }
        void Dispose();
        bool IsDisposed { get; }
    }
}
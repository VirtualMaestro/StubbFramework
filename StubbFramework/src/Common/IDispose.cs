namespace StubbFramework.Common
{
    public interface IDispose : System.IDisposable
    {
        bool IsDisposed { get; }
    }
}
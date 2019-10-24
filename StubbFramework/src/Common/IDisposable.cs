namespace StubbFramework.Common
{
    public interface IDisposable : System.IDisposable
    {
        bool IsDisposed { get; }
    }
}
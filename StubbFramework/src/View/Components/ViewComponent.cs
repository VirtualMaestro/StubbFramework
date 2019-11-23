using Leopotam.Ecs;

namespace StubbFramework.View.Components
{
    public sealed class ViewComponent : IEcsAutoReset
    {
        public IViewObject View;
        
        public void Reset()
        {
            if (View.IsDisposed == false)
            {
                View.Dispose();
                View = null;
            }
        }
    }
}
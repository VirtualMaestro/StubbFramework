using Leopotam.Ecs;

namespace StubbFramework.View.Components
{
    public class ViewComponent : IEcsAutoReset
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
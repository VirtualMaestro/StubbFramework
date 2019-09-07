using Leopotam.Ecs;

namespace StubbFramework.View
{
    public class ViewComponent : IEcsAutoResetComponent
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
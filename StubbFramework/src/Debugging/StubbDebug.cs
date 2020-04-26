using Leopotam.Ecs;

namespace StubbFramework.Debugging
{
    public class StubbDebug : IStubbDebug
    {
#if DEBUG
        Leopotam.Ecs.RemoteDebug.RemoteDebugClient _debug;
#endif
        public void Init(EcsSystems rootSystems, EcsWorld world)
        {
#if DEBUG
            _debug = new Leopotam.Ecs.RemoteDebug.RemoteDebugClient (world);
#endif 
        }

        public void Debug()
        {
#if DEBUG
            _debug?.Run ();
#endif
        }
    }
}
using Leopotam.Ecs;

namespace StubbFramework
{
    internal static class SystemsTailConfig
    {
        internal static EcsSystems Create()
        {
            var tailSystems = new EcsSystems(Stubb.Instance.World, "SystemsTail");
            
            

            return tailSystems;
        }
    }
}
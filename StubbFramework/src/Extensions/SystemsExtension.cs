using Leopotam.Ecs;

namespace StubbFramework.Extensions
{
    public static class SystemsExtension
    {
        public static void Add(this EcsSystems systems, EcsFeature feature)
        {
            systems.Add(feature.Systems, feature.Name);
        }
    }
}
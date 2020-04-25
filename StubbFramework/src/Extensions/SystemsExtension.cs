using Leopotam.Ecs;

namespace StubbFramework.Extensions
{
    public static class SystemsExtension
    {
        public static void AddFeature(this EcsSystems systems, EcsFeature feature)
        {
            systems.Add(feature);
            systems.Add(feature.Systems, feature.Name);
            feature.Parent = systems;
        }
    }
}
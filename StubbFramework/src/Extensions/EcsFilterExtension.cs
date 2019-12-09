using System;
using Leopotam.Ecs;

namespace StubbFramework.Extensions
{
    public static class EcsFilterExtension
    {
        public static T Single<T>(this EcsFilter<T> filter) where T : class
        {
            #if DEBUG
                if (filter.IsEmpty()) throw new Exception($"EcsFilterExtension.Single. Filter with type {typeof(T)} is empty!");
                if (filter.GetEntitiesCount() > 1) throw new Exception($"EcsFilterExtension.Single. Filter with type {typeof(T)} is used as single but contains more than one entity!");
            #endif
            
            return filter.Get1[0];
        }

        public static void Clear<T> (this EcsFilter<T> filter) where T : class
        {
            foreach (var idx in filter)
            {
                filter.Entities[idx].Destroy();
            }
        }
    }
}
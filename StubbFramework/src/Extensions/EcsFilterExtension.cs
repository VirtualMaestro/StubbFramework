﻿using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Remove.Components;

namespace StubbFramework.Extensions
{
    public static class EcsFilterExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Single<T>(this EcsFilter<T> filter) where T : struct
        {
#if DEBUG
            if (filter.IsEmpty()) throw new System.Exception($"EcsFilterExtension.Single. Filter with type {typeof(T)} is empty!");
            if (filter.GetEntitiesCount() > 1) throw new System.Exception($"EcsFilterExtension.Single. Filter with type {typeof(T)} is used as single but contains more than one entity!");
#endif
            
            return filter.Get1(0);
        }

        /// <summary>
        /// Immediately removes all entities in given filter.
        /// Use it carefully!
        /// </summary>
        public static void Clear<T> (this EcsFilter<T> filter) where T : struct
        {
            foreach (var idx in filter)
            {
                filter.GetEntity(idx).Destroy();
            }
        }

        /// <summary>
        /// Mark all entities in a filter with RemoveEntityComponent. 
        /// </summary>
        public static void MarkRemove (this EcsFilter filter)
        {
            foreach (var idx in filter)
            {
                filter.GetEntity(idx).Get<RemoveEntityComponent>();
            }
        }
    }
}
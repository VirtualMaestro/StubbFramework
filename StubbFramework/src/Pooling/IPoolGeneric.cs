using System;

namespace StubbFramework.Pooling
{
    public interface IPoolGeneric
    {
        /// <summary>
        /// Check if pool empty.
        /// It can be also used to know if an instance that was returned by 'Get' is newly created or got from the pool.
        /// var isItemNewlyCreated = pool.IsEmpty;
        /// var item = pool.Get();
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Check if the pool is full.
        /// </summary>
        bool IsFull { get; }
        /// <summary>
        /// Check if the pool is destroyed.
        /// </summary>
        bool IsDisposed { get; }
        /// <summary>
        /// Returns number of how many slots still available in the pool.
        /// </summary>
        int Available { get; }
        /// <summary>
        /// Total pool size.
        /// </summary>
        int Size { get; }
        /// <summary>
        /// Pre-creates instances for all available slots in the pool.
        /// </summary>
        void PreWarm();
        /// <summary>
        /// Pre-creates the given number of the instances in the pool.
        /// </summary>
        void PreWarm(int count);
        /// <summary>
        /// Clear all the pool.
        /// </summary>
        /// <param name="shrink">if 'true' the pool will be shrunk to the 'initialCapacity'. </param>
        void Clear(bool shrink = false);
        /// <summary>
        /// Dispose the pool. After this the pool can't be used anymore.
        /// </summary>
        void Dispose();
        /// <summary>
        /// The event is sent before the pool is disposed of.
        /// </summary>
        event RemovePool OnRemove;
    }

    public delegate void RemovePool(IPoolGeneric pool, Type type);
}
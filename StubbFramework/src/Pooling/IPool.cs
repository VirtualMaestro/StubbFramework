using System;

namespace StubbFramework.Pooling
{
    public interface IPool<T> : IPoolGeneric
    {
        /// <summary>
        /// Set create method which will create new instances.
        /// </summary>
        Func<T> CreateMethod { set; }
        /// <summary>
        /// Set creator for the strategy of creating, putting and getting instances.
        /// </summary>
        ICreator<T> Creator { set; }
        /// <summary>
        /// Get or create item from the pool.
        /// </summary>
        T Get();
        /// <summary>
        /// Store item in the pool.
        /// </summary>
        void Put(T t);
    }
}
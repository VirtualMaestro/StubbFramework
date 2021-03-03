using System;

namespace StubbFramework.Pooling
{
    /// <summary>
    /// Responsibilities:
    /// 1. How the instance of the stored type should be created, when the pool doesn't have enough instances.
    /// 2. How instance should be properly initialized during getting from the pool.
    /// 3. How instance should be properly deactivated during storing it in a pool. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreator<T> : IDisposable
    {
        /// <summary>
        /// Invokes when instance of poolable item has to be created.
        /// </summary>
        T Create();
        /// <summary>
        /// Invokes when item is going to be stored in the pool.
        /// </summary>
        void BeforeStore(T t);
        /// <summary>
        /// Invokes when item is going to be got from the pool.
        /// </summary>
        void AfterRestore(T t);
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace StubbFramework.Pooling
{
    public class Pools
    {
        #region Singleton
        private static Pools _instance;  
        public static Pools I => _instance ?? (_instance = new Pools());
        #endregion

        private readonly Dictionary<Type, IPoolGeneric> _pools;

        public int NumPools => _pools.Count;
        
        private Pools()
        {
            _pools = new Dictionary<Type, IPoolGeneric>();
        }

        /// <summary>
        /// Creates a pool with given type.
        /// </summary>
        /// <param name="capacity">Initial capacity of the pool. Min value is 10.</param>
        public IPool<T> Create<T>(int capacity)
        {
            _CheckIfPoolAlreadyExist<T>();

            var pool = new Pool<T>(capacity);
            pool.OnRemove += OnRemovePoolHandler;
            _pools[typeof(T)] = pool;
            
            return pool;
        }
        
        /// <summary>
        /// Creates a pool with given type.
        /// </summary>
        /// <param name="capacity">Initial capacity of the pool. Min value is 10.</param>
        /// <param name="creator">Instance of ICreator which will be used for creating an instance of pool's type.</param>
        /// <param name="prewarm">If 'true' will be created the number of instances equal to the 'capacity' of the pool.</param>
        public IPool<T> Create<T>(int capacity, ICreator<T> creator, bool prewarm = false)
        {
            var pool = Create<T>(capacity);
            pool.Creator = creator;
            
            if (prewarm) 
                pool.PreWarm(pool.Size);

            return pool;
        }

        /// <summary>
        /// Creates a pool with given type.
        /// </summary>
        /// <param name="capacity">Initial capacity of the pool. Min value is 10.</param>
        /// <param name="createMethod">Method which will be used for creating an instance of pool's type.</param>
        /// <param name="prewarm">If 'true' will be created the number of instances equal to the 'capacity' of the pool.</param>
        public IPool<T> Create<T>(int capacity, Func<T> createMethod, bool prewarm = false)
        {
            var pool = Create<T>(capacity);
            pool.CreateMethod = createMethod;

            if (prewarm) 
                pool.PreWarm(pool.Size);

            return pool;
        }

        /// <summary>
        /// Returns a pool by given type.
        /// </summary>
        public IPool<T> Get<T>()
        {
            _CheckIfPoolDoesntExist<T>();

            return _pools[typeof(T)] as Pool<T>;
        }

        /// <summary>
        /// Clears all pools.
        /// </summary>
        /// <param name="shrink">if 'true' the pools will be shrunk</param>
        public void ClearAll(bool shrink = false)
        {
            foreach (var pair in _pools)
            {
                pair.Value.Clear(shrink);
            }
        }

        /// <summary>
        /// Disposes all pools.
        /// </summary>
        public void DisposeAll()
        {
            foreach (var pair in _pools)
            {
                pair.Value.OnRemove -= OnRemovePoolHandler;
                pair.Value.Dispose();
            }
            
            _pools.Clear();
        }

        public bool Has<T>()
        {
            return Has(typeof(T));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(Type type)
        {
            return _pools.ContainsKey(type);
        }

        private void OnRemovePoolHandler(IPoolGeneric sender, Type type)
        {
            _pools.Remove(type);
        }

        [Conditional("DEBUG")]
        private void _CheckIfPoolDoesntExist<T>()
        {
            if (!Has<T>())
            {
                throw new Exception($"Pool with type {typeof(T)} doesn't exist! Make sure you register before use.");
            }
        }

        [Conditional("DEBUG")]
        private void _CheckIfPoolAlreadyExist<T>()
        {
            if (Has<T>())
            {
                throw new Exception($"Pool with type {typeof(T)} already exist!");
            }
        }
    }
}
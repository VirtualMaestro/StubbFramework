using System.Collections;
using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public class LoadingScenesConfig : ILoadingScenesConfig
    {
        public static ILoadingScenesConfig Create(bool isActive = true)
        {
            return new LoadingScenesConfig(isActive);
        }
        
        private Queue<ILoadingSceneConfig> _queue;
        
        public bool IsActive { get; }
        public bool IsEmpty => _queue.Count == 0;

        public LoadingScenesConfig(bool isActive = true)
        {
            _queue = new Queue<ILoadingSceneConfig>(3);
            IsActive = isActive;
        }

        public ILoadingScenesConfig Add(ILoadingSceneConfig config)
        {
            _queue.Enqueue(config);
            return this;
        }

        public ILoadingScenesConfig Add(string sceneName, string scenePath = null, bool isAdditive = true)
        {
            _queue.Enqueue(new LoadingSceneConfig(sceneName, scenePath, isAdditive));
            return this;
        }

        public void Pop()
        {
            _queue.Dequeue();
        }

        public ILoadingScenesConfig Clone()
        {
            var loadingList = new LoadingScenesConfig(IsActive);

            foreach (var item in _queue)
            {
                loadingList.Add(item.Clone());
            }
            
            return loadingList;
        }

        public IEnumerator<ILoadingSceneConfig> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
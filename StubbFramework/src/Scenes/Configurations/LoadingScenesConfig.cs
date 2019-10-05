using System.Collections;
using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public class LoadingScenesConfig : ILoadingScenesConfig
    {
        public static ILoadingScenesConfig Create(string name, bool isActive = true)
        {
            return new LoadingScenesConfig(name, isActive);
        }
        
        private Queue<ILoadingSceneConfig> _queue;
        
        public string Name { get; }
        public bool IsActive { get; }
        public bool IsEmpty => _queue.Count == 0;

        public LoadingScenesConfig(string name, bool isActive = true)
        {
            _queue = new Queue<ILoadingSceneConfig>(3);
            Name = name;
            IsActive = isActive;
        }

        public ILoadingScenesConfig Add(ILoadingSceneConfig config)
        {
            _queue.Enqueue(config);
            return this;
        }

        public ILoadingScenesConfig Add(string sceneName, bool isActive, bool isAdditive)
        {
            _queue.Enqueue(new LoadingSceneConfig(sceneName) {IsActive = isActive, IsAdditive = isAdditive});
            return this;
        }

        public void Pop()
        {
            _queue.Dequeue();
        }

        public ILoadingScenesConfig Clone()
        {
            var loadingList = new LoadingScenesConfig(Name, IsActive);

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
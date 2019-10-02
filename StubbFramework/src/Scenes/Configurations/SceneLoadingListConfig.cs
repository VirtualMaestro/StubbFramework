using System.Collections;
using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public class SceneLoadingListConfig : ISceneLoadingListConfig
    {
        private Queue<ISceneLoadingConfig> _queue;
        
        public string Name { get; }
        public bool IsActive { get; }
        public bool IsEmpty => _queue.Count == 0;

        public SceneLoadingListConfig(string name, bool isActive = true)
        {
            _queue = new Queue<ISceneLoadingConfig>(3);
            Name = name;
            IsActive = isActive;
        }

        public ISceneLoadingListConfig Add(ISceneLoadingConfig config)
        {
            _queue.Enqueue(config);
            return this;
        }

        public void Pop()
        {
            _queue.Dequeue();
        }

        public ISceneLoadingListConfig Clone()
        {
            var loadingList = new SceneLoadingListConfig(Name, IsActive);

            foreach (var item in _queue)
            {
                loadingList.Add(item.Clone());
            }
            
            return loadingList;
        }

        public IEnumerator<ISceneLoadingConfig> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
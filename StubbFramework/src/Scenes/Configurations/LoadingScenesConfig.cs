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
        
        private readonly List<ILoadingSceneConfig> _list;
        
        public bool IsActivatingAll { get; }

        public LoadingScenesConfig(bool isActive = true)
        {
            _list = new List<ILoadingSceneConfig>(3);
            IsActivatingAll = isActive;
        }

        public ILoadingScenesConfig Add(ILoadingSceneConfig config)
        {
            _list.Add(config);
            return this;
        }

        public ILoadingScenesConfig Add(string sceneName, string scenePath = null, bool isAdditive = true)
        {
            Add(new LoadingSceneConfig(sceneName, scenePath, isAdditive));
            return this;
        }

        public ILoadingScenesConfig Clone()
        {
            var loadingList = new LoadingScenesConfig(IsActivatingAll);

            foreach (var item in _list)
            {
                loadingList.Add(item.Clone());
            }
            
            return loadingList;
        }

        public IEnumerator<ILoadingSceneConfig> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
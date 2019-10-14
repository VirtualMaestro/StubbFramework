using System.Collections;
using System.Collections.Generic;

namespace StubbFramework.Scenes.Configurations
{
    public class LoadingScenesConfig : ILoadingScenesConfig
    {
        public static ILoadingScenesConfig Create(bool isActivatingAll = true)
        {
            return new LoadingScenesConfig(isActivatingAll);
        }
        
        private readonly List<ILoadingSceneConfig> _list;
        
        public bool IsActivatingAll { get; }
        public int NumScenes => _list.Count;

        public LoadingScenesConfig(bool isActivatingAll = true)
        {
            _list = new List<ILoadingSceneConfig>(3);
            IsActivatingAll = isActivatingAll;
        }

        public ILoadingScenesConfig Add(ILoadingSceneConfig config)
        {
            _list.Add(config);
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
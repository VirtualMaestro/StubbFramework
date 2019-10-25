using System.Collections.Generic;

namespace StubbFramework.Common.Names
{
    public class AssetNamesBuilder<T> where T: IAssetName, new()
    {
        private readonly List<T> _names;
        
        public List<T> Build => _names;
        
        public AssetNamesBuilder()
        {
            _names = new List<T>();
        }

        public AssetNamesBuilder<T> Add(string name, string path = null)
        {
            T assetName = new T();
            assetName.Set(name, path);
            _names.Add(assetName);
            
            return this;
        }
    }
}
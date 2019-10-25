using System.Collections.Generic;

namespace StubbFramework.Common.Names
{
    public class AssetNamesBuilder<T> where T: IAssetName, new()
    {
        private readonly List<IAssetName> _names;
        
        public List<IAssetName> Build => _names;
        
        public AssetNamesBuilder()
        {
            _names = new List<IAssetName>();
        }

        public AssetNamesBuilder<T> Add(string name, string path = null)
        {
            IAssetName assetName = new T();
            assetName.Set(name, path);
            _names.Add(assetName);
            
            return this;
        }
    }
}
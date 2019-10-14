using System.Collections.Generic;

namespace StubbFramework.Scenes
{
    public class SceneName : ISceneName
    {
        public static SceneNameBuilder Create => new SceneNameBuilder();
        
        public string Name { get; }
        public string Path { get; }
        public string FullName { get; }

        public SceneName(string name, string path = null)
        {
            Name = name;
            Path = path;
            FullName = path + name;
        }

        public override string ToString()
        {
            return FullName;
        }

        public ISceneName Clone()
        {
            return new SceneName(Name, Path);
        }
    }

    public class SceneNameBuilder
    {
        private readonly IList<ISceneName> _sceneNames;
        
        public IList<ISceneName> Build => _sceneNames;
        
        public SceneNameBuilder()
        {
            _sceneNames = new List<ISceneName>();
        }

        public SceneNameBuilder Add(string sceneName, string scenePath = null)
        {
            _sceneNames.Add(new SceneName(sceneName, scenePath));
            return this;
        }
    }
}
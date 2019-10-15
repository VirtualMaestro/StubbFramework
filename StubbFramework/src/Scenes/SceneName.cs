using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace StubbFramework.Scenes
{
    public class SceneName : ISceneName
    {
        private static readonly Regex NormalizePathRegex = new Regex(@"^\s*/|Assets/|\w+.unity", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        
        public static SceneNameBuilder Create => new SceneNameBuilder();

        public string Name { get; }
        public string Path { get; }
        public string FullName { get; }

        public SceneName(string name, string path = null)
        {
            Name = name;
            Path = _NormalizePath(path);
            FullName = Path + Name;
        }

        public bool Equals(ISceneName other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return FullName.Equals(other.FullName);
        }

        public override string ToString()
        {
            return FullName;
        }

        public ISceneName Clone()
        {
            return new SceneName(Name, Path);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string _NormalizePath(string path)
        {
            if (path == null || (path = path.Trim()) == string.Empty) return string.Empty;
            path = path.Replace("\\", "/");
            path = NormalizePathRegex.Replace(path, "");

            if (path[path.Length - 1] != '/') path += "/";

            return path;
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
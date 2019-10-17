using System;
using StubbUnity.Logging;

namespace StubbFramework.Scenes
{
    public abstract class AbstractSceneName : ISceneName
    {
        public string Name { get; }
        public string Path { get; }
        public string FullName { get; }

        public AbstractSceneName(string name, string path = null)
        {
            Name = FormatName(name);
            Path = FormatPath(path);
            FullName = FormatFullName(Name, Path);
        }

        public virtual bool Equals(ISceneName other)
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

        public virtual ISceneName Clone()
        {
            throw new NotImplementedException();
        }

        protected virtual string FormatName(string sceneName)
        {
            sceneName = sceneName.Trim();
            log.Assert(sceneName != string.Empty, $"Incorrect scene name '{sceneName}'!");
            return sceneName;
        }

        protected virtual string FormatPath(string path)
        {
            return (path == null || (path = path.Trim()) == string.Empty) ? string.Empty : path;
        }

        protected virtual string FormatFullName(string name, string path)
        {
            return path + name;
        }
    }
}
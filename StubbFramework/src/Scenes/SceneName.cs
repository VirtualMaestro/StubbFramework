namespace StubbFramework.Scenes
{
    public class SceneName : ISceneName
    {
        public string Name { get; }
        public string Path { get; }
        public string FullName { get; }

        public SceneName(string name, string path = null)
        {
            Name = name;
            Path = path;
            FullName = path + name;
        }

        public ISceneName Clone()
        {
            return new SceneName(Name, Path);
        }
    }
}
namespace StubbFramework.Scenes
{
    public interface ISceneName
    {
        string Name { get; }
        string Path { get; }
        string FullName { get; }
        ISceneName Clone();
    }
}
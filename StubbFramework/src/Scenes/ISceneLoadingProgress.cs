namespace StubbFramework.Scenes
{
    public interface ISceneLoadingProgress
    {
        bool IsComplete { get; }
        float Progress { get; }
        object Payload { get; }
    }
}
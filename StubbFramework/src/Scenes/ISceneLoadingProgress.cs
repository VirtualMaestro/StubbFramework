namespace StubbFramework.Scenes
{
    public interface ISceneLoadingProgress
    {
        ISceneName SceneName { get; }
        bool IsComplete { get; }
        float Progress { get; }
        object Payload { get; }
    }
}
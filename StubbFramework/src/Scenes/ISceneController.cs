namespace StubbFramework.Scenes
{
    /// <summary>
    /// Interface for the SceneController which should be implemented in engine specific class.
    /// It will contain original Scene specific engine instance .
    /// </summary>
    public interface ISceneController
    {
        void Initialize();
        void ShowContent();
        void HideContent();
        bool IsContentActive { get; }
        bool IsDestroyed { get; }
        string SceneName { get; }
        string ScenePath { get; }
        void Destroy();
    }
}
namespace StubbFramework.Scenes
{
    public interface ISceneController
    {
        void Initialize();
        void ShowContent();
        void HideContent();
        bool IsContentActive { get; }
        bool IsDestroyed { get; }
        string SceneName { get; }
        void Destroy();
    }
}
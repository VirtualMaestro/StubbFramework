namespace StubbFramework.Scenes
{
    public interface ISceneController
    {
        void Initialize();
        void ShowContent();
        void HideContent();
        bool IsContentActive { get; }
        string SceneName { get; }
        void Destroy();
    }
}
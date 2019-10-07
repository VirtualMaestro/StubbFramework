namespace StubbFramework.Scenes
{
    public interface ISceneContent
    {
        void ShowContent();
        void HideContent();
        bool IsContentActive { get; }
    }
}
namespace StubbFramework.Scenes
{
    public interface ISceneContentController
    {
        bool IsActive { get; }
        void Show();
        void Hide();
        void Destroy();
    }
}
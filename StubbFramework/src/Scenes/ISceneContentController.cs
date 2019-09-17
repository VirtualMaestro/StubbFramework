namespace StubbFramework.Scenes
{
    public interface ISceneContentController
    {
        bool IsActive();
        void Show();
        void Hide();
        void Destroy();
    }
}
using StubbFramework.Common;
using StubbFramework.Common.Names;

namespace StubbFramework.Scenes
{
    /// <summary>
    /// Interface for the SceneController which should be implemented in engine specific class.
    /// It will contain original Scene specific engine instance .
    /// </summary>
    public interface ISceneController : ISceneContent, IEntityContainer
    {
        void Initialize();
        IAssetName SceneName { get; }
        bool IsDestroyed { get; }
        bool IsMain { get; }
        void SetAsMain();
        void Destroy();
    }
}
namespace StubbFramework.Scenes
{
    public interface ISceneContent
    {
        /// <summary>
        /// For internal use. For showing scene use World.ActivateSceneByName() or World.ActivateScene().
        /// </summary>
        void ShowContent();
        /// <summary>
        /// For internal use. For hiding scene use World.DeactivateSceneByName() or World.DeactivateScene().
        /// </summary>
        void HideContent();
        /// <summary>
        /// Determines if scene is active.
        /// </summary>
        bool IsContentActive { get; }
    }
}
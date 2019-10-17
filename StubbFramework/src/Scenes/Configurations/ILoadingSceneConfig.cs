namespace StubbFramework.Scenes.Configurations
{
    public interface ILoadingSceneConfig
    {
        ISceneName Name { get; }
        /// <summary>
        /// Returns true if after loading, the content will be shown.
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// Returns true if after loading scene should be marked as main.
        /// </summary>
        bool IsMain { get; }
        
        object Payload { get; set; }
        
        ILoadingSceneConfig Clone();
     }
}
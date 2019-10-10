using Leopotam.Ecs;

namespace StubbFramework.Common.Components
{
    /// <summary>
    /// General flag component which indicates new entity which was added to the world.
    /// This component will be removed from an entity in the end of the loop. 
    /// </summary>
    public class NewEntityComponent : IEcsOneFrame, IEcsIgnoreInFilter 
    {
        
    }
}
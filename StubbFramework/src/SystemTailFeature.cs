using Leopotam.Ecs;
using StubbFramework.Common.Components;
using StubbFramework.Remove.Systems;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Systems;
using StubbFramework.View.Systems;

namespace StubbFramework
{
    public class SystemTailFeature : EcsFeature
    {
        public SystemTailFeature(EcsWorld world, string name = null) : base(world,name ?? "TailSystems")
        {}

        protected override void SetupSystems()
        {
            Add(new LoadScenesSystem());
            
            Add(new UnloadScenesByNamesSystem());
            Add(new UnloadAllScenesSystem());
            Add(new UnloadNonNewScenesSystem());
            Add(new UnloadSceneSystem());
            
            OneFrame<IsSceneStateChangedComponent>();
            
            Add(new ChangeSceneStateByNameSystem());
            Add(new ActivateSceneSystem());
            Add(new DeactivateSceneSystem());
            
            Add(new RemoveViewSystem());
            Add(new RemoveEntitySystem());
            
            OneFrame<ActivateSceneByNameEvent>();
            OneFrame<DeactivateSceneByNameEvent>();
            OneFrame<ActivateSceneEvent>();
            OneFrame<DeactivateSceneEvent>();
            OneFrame<IsNewEvent>();
            OneFrame<UnloadNonNewScenesEvent>();
            OneFrame<UnloadAllScenesEvent>();
            OneFrame<UnloadScenesByNamesEvent>();
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Remove.Systems;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Events;
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
            Add(new LoadingScenesProgressSystem());

            Add(new UnloadScenesByNamesSystem());
            Add(new UnloadAllScenesSystem());
            Add(new UnloadNonNewScenesSystem());
            Add(new UnloadSceneSystem());
            
            OneFrame<SceneChangedStateComponent>();
            
            Add(new ChangeSceneStateByNameSystem());
            Add(new ActivateSceneSystem());
            Add(new DeactivateSceneSystem());
            
            Add(new RemoveEcsViewLinkSystem());
            Add(new RemoveEntitySystem());
            
            OneFrame<ActivateSceneComponent>();
            OneFrame<DeactivateSceneComponent>();
            OneFrame<SceneLoadedComponent>();

            OneFrame<LoadScenesEvent>();
            OneFrame<ActivateSceneByNameEvent>();
            OneFrame<DeactivateSceneByNameEvent>();
            OneFrame<UnloadNonNewScenesEvent>();
            OneFrame<UnloadAllScenesEvent>();
            OneFrame<UnloadScenesByNamesEvent>();
        }
    }
}
using Leopotam.Ecs;
using StubbFramework.Core;
using StubbFramework.Scenes.Components;
using StubbFramework.Scenes.Events;
using StubbFramework.Scenes.Systems;

namespace StubbFramework.Scenes
{
    public class SceneFeature : EcsFeature
    {
        public SceneFeature(EcsWorld world, string name = null, bool isEnable = true) : base(world, name, isEnable)
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
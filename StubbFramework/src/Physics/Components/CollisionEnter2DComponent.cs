namespace StubbFramework.Physics.Components
{
    /// <summary>
    /// Contains collision info of 2d physics for Enter phase.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct CollisionEnter2DComponent
    {
        public IEcsViewPhysics ObjectA;
        public IEcsViewPhysics ObjectB;
        public object Info;
    }
}
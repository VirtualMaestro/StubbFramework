﻿namespace StubbFramework.Physics.Components
{
    /// <summary>
    /// Contains trigger info of 3d physics for Exit phase.
    /// </summary>
#if ENABLE_IL2CPP
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.NullChecks, false)]
    [Unity.IL2CPP.CompilerServices.Il2CppSetOption (Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false)]
#endif
    public struct TriggerExitComponent
    {
        public IEcsViewPhysics ObjectA;
        public IEcsViewPhysics ObjectB;
        public object Info;
    }
}
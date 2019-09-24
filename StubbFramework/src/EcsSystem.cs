﻿using System.Runtime.CompilerServices;
using Leopotam.Ecs;

namespace StubbFramework
{
    public class EcsSystem : IEcsInitSystem, IEcsRunSystem
    {
        protected EcsWorld World
        {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => Stubb.World;
        }
        public virtual void Initialize()
        {
        }

        public virtual void Run()
        {
        }

        public virtual void Destroy()
        {
        }
     }
}
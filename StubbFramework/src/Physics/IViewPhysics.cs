﻿using StubbFramework.View;

namespace StubbFramework.Physics
{
    public interface IViewPhysics : IViewObject
    {
        int TypeId { get; set; }
        bool EnableTriggerEnter { get; set; }
        bool EnableTriggerStay { get; set; }
        bool EnableTriggerExit { get; set; }

        bool EnableCollisionEnter { get; set; }
        bool EnableCollisionStay { get; set; }
        bool EnableCollisionExit { get; set; }
    }
}
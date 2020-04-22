using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StubbFramework.Physics;

namespace StubbFramework
{
    public static class Stubb
    {
        private static List<IStubbContext> _contexts = new List<IStubbContext>(3);

        /// <summary>
        /// Adds context to the list.
        /// IPhysicsContext will be always after all usual IStubbContext.
        /// </summary>
        /// <param name="context"></param>
        public static void AddContext(IStubbContext context)
        {
            var index = _contexts.Count;

            if (_contexts.Count > 0 && !(context is IPhysicsContext))
            {
                index = _contexts.FindIndex(stubbContext => stubbContext is IPhysicsContext);
                index = index == -1 ? _contexts.Count : index;
            }

            _contexts.Insert(index, context);
        }

        public static int NumContexts => _contexts.Count;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IStubbContext GetContext(int index = 0)
        {
            index = index < 0 ? 0 : index;
            index = index > _contexts.Count - 1 ? _contexts.Count - 1 : index;

            return _contexts[index];
        }

        /// <summary>
        /// Main world which is taken from a first context.
        /// </summary>
        public static EcsWorld World => _contexts[0].World;

        public static void Clear()
        {
            _contexts = new List<IStubbContext>(3);
        }
    }
}
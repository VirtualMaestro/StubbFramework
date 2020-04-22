﻿using System.Runtime.CompilerServices;

namespace StubbFramework
{
    public static class Stubb
    {
        private static int _index;
        private static IStubbContext[] _contexts = new IStubbContext[10];

        public static void AddContext(IStubbContext context)
        {
            _contexts[_index++] = context;
        }

        public static int NumContexts => _contexts.Length;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static IStubbContext GetContext(int index = 0)
        {
            return _contexts[index];
        }

        public static void Clear()
        {
            _index = 0;
            _contexts = new IStubbContext[10];
        }
    }
}
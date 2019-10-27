namespace StubbFramework
{
    public static class Stubb
    {
        private static int _index = 0;
        private static IStubbContext[] _contexts = new IStubbContext[10];

        public static void AddContext(IStubbContext context)
        {
            _contexts[_index++] = context;
        }

        public static IStubbContext GetContext(int index)
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
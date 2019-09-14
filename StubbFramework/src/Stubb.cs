using Leopotam.Ecs;

namespace StubbFramework
{
    public static class Stubb
    {
        private static IStubbContext _context;

        public static void Create(IStubbContext context = null)
        {
            _context = context ?? new StubbContextDefault();
        }
        
        public static EcsWorld World => _context.World;

        public static void Initialize()
        {
            _context.Initialize();
        }
        
        public static void Add(EcsSystems ecsSystems)
        {
            _context.Add(ecsSystems);
        }

        public static void Update()
        {
            _context.Update();
        }

        public static void Dispose()
        {
            _context.Dispose();
        }
    }
}
using Leopotam.Ecs;

namespace StubbFramework
{
    public static class Stubb
    {
        private static IStubbContext _context;

        public static void Create(IStubbContext context = null)
        {
            _context = context ?? new StubbContextDefault();
            _context.Create();
        }
        
        public static EcsWorld World => _context.World;

        public static void Initialize()
        {
            _context.Initialize();
        }
        
        public static void Add(IEcsSystem ecsSystem)
        {
            _context.Add(ecsSystem);
        }

        public static void Run()
        {
            _context.Run();
        }

        public static void Dispose()
        {
            _context.Dispose();
        }
    }
}
using System;

namespace StubbFramework
{
    public class Stubb
    {
        private Stubb()
        {}
        
        private static readonly Lazy<Stubb> _lazy = new Lazy<Stubb>(() => new Stubb());

        public static Stubb Instance => _lazy.Value;
    }
}
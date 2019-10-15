using System;

namespace StubbFramework.Scenes
{
    public interface ISceneName : IEquatable<ISceneName>
    {
        string Name { get; }
        string Path { get; }
        string FullName { get; }
        ISceneName Clone();
    }
}
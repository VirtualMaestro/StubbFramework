using System;

namespace StubbFramework.Scenes
{
    public interface IAssetName : IEquatable<IAssetName>
    {
        string Name { get; }
        string Path { get; }
        string FullName { get; }
        IAssetName Clone();
    }
}
using AnimalWorld.Animal;
using UnityEngine;

namespace AnimalWorld.Resolver
{
    public sealed class IgnoreCommand : ICollisionCommand
    {
        public static readonly IgnoreCommand Instance = new();

        private IgnoreCommand() { }

        public void Execute(AnimalMono self, Collision collision) { }
    }
}

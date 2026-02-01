using AnimalWorld.Animal;
using UnityEngine;

namespace AnimalWorld.Resolver
{
    public sealed class EatOtherCommand : ICollisionCommand
    {
        private readonly IAnimal _other;

        public EatOtherCommand(IAnimal other)
        {
            _other = other;
        }

        public void Execute(AnimalMono self, Collision collision)
        {
            _other.Kill();
        }
    }
}

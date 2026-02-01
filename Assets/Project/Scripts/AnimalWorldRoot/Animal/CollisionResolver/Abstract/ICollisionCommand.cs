using AnimalWorld.Animal;
using UnityEngine;

namespace AnimalWorld.Resolver
{
    public interface ICollisionCommand
    {
        void Execute(AnimalMono self, Collision collision);
    }
}

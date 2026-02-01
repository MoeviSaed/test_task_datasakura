using AnimalWorld.Animal;
using UnityEngine;

namespace AnimalWorld.Resolver
{
    public sealed class DieCommand : ICollisionCommand
    {
        public void Execute(AnimalMono self, Collision collision)
        {
            self.Kill();
        }
    }
}

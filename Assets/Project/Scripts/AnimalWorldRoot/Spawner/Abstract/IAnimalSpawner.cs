using System;
using AnimalWorld.Animal;

namespace AnimalWorld.Spawner
{
    public interface IAnimalSpawner
    {
        event Action<IAnimal> OnAnimalSpawned;
        void Tick(float deltaTime);
    }
}

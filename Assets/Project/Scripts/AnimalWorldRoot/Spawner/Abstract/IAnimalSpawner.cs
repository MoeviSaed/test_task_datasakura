using System;
using AnimalWorldRoot.Animal;

namespace AnimalWorldRoot.Spawner
{
    public interface IAnimalSpawner
    {
        event Action<IAnimal> OnAnimalSpawned;
        void Tick(float deltaTime);
    }
}

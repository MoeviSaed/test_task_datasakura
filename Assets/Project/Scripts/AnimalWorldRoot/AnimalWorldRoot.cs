using System.Collections.Generic;
using AnimalWorldRoot.Animal;
using AnimalWorldRoot.Factory;
using AnimalWorldRoot.Spawner;
using AnimalWorldRoot.Statistics;
using Modules.ScreenBounds;
using UnityEngine;

namespace AnimalWorldRoot
{
    public class AnimalWorldRoot
    {
        public IAnimalWorldStats animalWorldStats { get; }

        private readonly IAnimalSpawner _animalSpawner;
        private readonly List<IAnimal> _animals;

        public AnimalWorldRoot(AnimalsConfig.AnimalsConfig animalsConfig, Transform animalsRoot,
            IScreenBounds screenBounds, float spawnIntervalMin, float spawnIntervalMax)
        {
            _animals = new List<IAnimal>();

            IAnimalFactory animalFactory = new AnimalFactory(animalsRoot, screenBounds);

            _animalSpawner = new AnimalSpawner(
                animalFactory,
                animalsConfig,
                _animals,
                spawnIntervalMin,
                spawnIntervalMax
            );

            animalWorldStats = new AnimalWorldStats(_animalSpawner);
        }

        public void Tick(float deltaTime)
        {
            _animalSpawner?.Tick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime)
        {
            foreach (IAnimal animal in _animals)
            {
                animal.Tick(fixedDeltaTime);
            }
        }
    }
}

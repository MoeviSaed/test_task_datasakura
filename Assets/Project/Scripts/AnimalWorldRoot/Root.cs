using System.Collections.Generic;
using AnimalWorld.Animal;
using AnimalWorld.Factory;
using AnimalWorld.Spawner;
using AnimalWorld.Statistics;
using Modules.ScreenBounds;
using UnityEngine;

namespace AnimalWorld
{
    public class Root
    {
        public class Context
        {
            public AnimalsConfig.AnimalsConfig animalsConfig;
            public Transform animalsRoot;
            public IScreenBounds screenBounds;
            public float spawnIntervalMin;
            public float spawnIntervalMax;
        }

        public IAnimalWorldStats animalWorldStats { get; }

        private readonly IAnimalSpawner _animalSpawner;
        private readonly List<IAnimal> _animals;

        public Root(Context context)
        {
            _animals = new List<IAnimal>();

            IAnimalFactory animalFactory = new AnimalFactory(context.animalsRoot, context.screenBounds);

            _animalSpawner = new AnimalSpawner(
                animalFactory,
                context.animalsConfig,
                _animals,
                context.spawnIntervalMin,
                context.spawnIntervalMax
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
                animal.MoveLifecycle(fixedDeltaTime);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using AnimalWorldRoot.Animal;
using AnimalWorldRoot.AnimalsConfig;
using AnimalWorldRoot.Factory;
using Random = UnityEngine.Random;

namespace AnimalWorldRoot.Spawner
{
    public class AnimalSpawner : IAnimalSpawner
    {
        public event Action<IAnimal> OnAnimalSpawned;

        private readonly IAnimalFactory _animalFactory;
        private readonly AnimalsConfig.AnimalsConfig _animalsConfig;
        private readonly List<IAnimal> _animals;
        private readonly float _spawnIntervalMin;
        private readonly float _spawnIntervalMax;

        private float _timer;

        public AnimalSpawner(IAnimalFactory animalFactory, AnimalsConfig.AnimalsConfig animalsConfig,
            List<IAnimal> animals, float spawnIntervalMin, float spawnIntervalMax)
        {
            _animalFactory = animalFactory;
            _animalsConfig = animalsConfig;
            _animals = animals;
            _spawnIntervalMin = spawnIntervalMin;
            _spawnIntervalMax = spawnIntervalMax;
        }

        public void Tick(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0f)
            {
                SpawnRandomAnimal();
                ResetTimer();
            }
        }

        private void ResetTimer()
        {
            _timer = Random.Range(_spawnIntervalMin, _spawnIntervalMax);
        }

        private void SpawnRandomAnimal()
        {
            if (_animalsConfig.animals.Length == 0)
            {
                throw new Exception("Add animals to config");
            }

            AnimalConfig config = _animalsConfig.animals[Random.Range(minInclusive: 0, _animalsConfig.animals.Length)];
            Spawn(config);
        }

        private void Spawn(AnimalConfig config)
        {
            IAnimal animal = _animalFactory.Create(config);
            _animals.Add(animal);

            OnAnimalSpawned?.Invoke(animal);
        }
    }
}

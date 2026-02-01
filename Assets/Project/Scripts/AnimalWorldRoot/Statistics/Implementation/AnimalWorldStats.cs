using System;
using System.Collections.Generic;
using AnimalWorldRoot.Animal;
using AnimalWorldRoot.AnimalsConfig;
using AnimalWorldRoot.Spawner;

namespace AnimalWorldRoot.Statistics
{
    public class AnimalWorldStats : IAnimalWorldStats
    {
        public event Action OnStatsChanged;

        public int DeadPreyCount => _deadPrey;
        public int DeadPredatorCount => _deadPredator;

        public IReadOnlyDictionary<AnimalType, int> countByType => _countByType;
        private readonly IAnimalSpawner _animalSpawner;

        private readonly Dictionary<AnimalType, int> _countByType = new();

        private int _deadPrey;
        private int _deadPredator;

        public AnimalWorldStats(IAnimalSpawner animalSpawner)
        {
            _animalSpawner = animalSpawner;
            _animalSpawner.OnAnimalSpawned += RegisterOnAnimal;
        }

        public void RegisterOnAnimal(IAnimal animal)
        {
            animal.OnDied += OnAnimalDied;
        }

        private void OnAnimalDied(IAnimal animal)
        {
            switch (animal.type)
            {
                case AnimalType.Prey:
                    _deadPrey++;
                    break;

                case AnimalType.Predator:
                    _deadPredator++;
                    break;
            }

            animal.OnDied -= OnAnimalDied;

            OnStatsChanged?.Invoke();
        }
    }
}

using System;
using AnimalWorld.Animal;
using AnimalWorld.AnimalsConfig;
using AnimalWorld.Spawner;

namespace AnimalWorld.Statistics
{
    public class AnimalWorldStats : IAnimalWorldStats
    {
        public event Action OnStatsChanged;

        public int DeadPreyCount => _deadPrey;
        public int DeadPredatorCount => _deadPredator;
        private readonly IAnimalSpawner _animalSpawner;

        private int _deadPrey;
        private int _deadPredator;

        public AnimalWorldStats(IAnimalSpawner animalSpawner)
        {
            _animalSpawner = animalSpawner;
            _animalSpawner.OnAnimalSpawned += RegisterOnAnimal;
        }

        private void RegisterOnAnimal(IAnimal animal)
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

                default:
                    throw new ArgumentOutOfRangeException();
            }

            animal.OnDied -= OnAnimalDied;

            OnStatsChanged?.Invoke();
        }
    }
}

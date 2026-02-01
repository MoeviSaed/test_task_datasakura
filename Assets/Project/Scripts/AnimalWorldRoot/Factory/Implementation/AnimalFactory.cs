using System;
using AnimalWorldRoot.Animal;
using AnimalWorldRoot.AnimalsConfig;
using AnimalWorldRoot.FoodChain;
using AnimalWorldRoot.MovementStrategy;
using Modules.ScreenBounds;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AnimalWorldRoot.Factory
{
    public class AnimalFactory : IAnimalFactory
    {
        private readonly Transform _root;
        private readonly IScreenBounds _screenBounds;

        public AnimalFactory(Transform root, IScreenBounds screenBounds)
        {
            _root = root;
            _screenBounds = screenBounds;
        }

        public IAnimal Create(AnimalConfig config)
        {
            AnimalView view = Object.Instantiate(
                config.animalPrefab,
                GetRandomSpawnPosition(),
                Quaternion.identity,
                _root
            );

            IMovementStrategy movement = config.movementType switch
            {
                MovementType.Jump => new JumpMovement(view, config.jumpForce, config.speed, _screenBounds),

                MovementType.Linear => new LinearMovement(
                    view,
                    Vector3.forward,
                    config.speed,
                    config.directionChangeInterval,
                    _screenBounds
                ),

                _ => throw new ArgumentOutOfRangeException()
            };

            IFoodChainBehaviour foodChain = config.animalType switch
            {
                AnimalType.Prey => new PreyFoodChain(),
                AnimalType.Predator => new PredatorFoodChain(),
                _ => throw new ArgumentOutOfRangeException()
            };

            view.Init(config.animalType, movement, foodChain);
            return view;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return new Vector3(
                Random.Range(minInclusive: -5f, maxInclusive: 5f),
                y: 0f,
                Random.Range(minInclusive: -5f, maxInclusive: 5f)
            );
        }
    }
}

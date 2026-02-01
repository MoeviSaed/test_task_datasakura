using System;
using AnimalWorld.Animal;
using AnimalWorld.AnimalsConfig;
using AnimalWorld.FoodChain;
using AnimalWorld.MovementStrategy;
using Modules.ScreenBounds;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AnimalWorld.Factory
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
            AnimalMono animalObject = Object.Instantiate(
                config.animalPrefab,
                GetRandomSpawnPosition(),
                Quaternion.identity,
                _root
            );

            IMovementStrategy movement = config.movementType switch
            {
                MovementType.Jump => new JumpMovement(animalObject, config.jumpForce, config.speed, _screenBounds),

                MovementType.Linear => new LinearMovement(
                    animalObject,
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

            var collisionResolver = new Resolver.CollisionResolver(animalObject, foodChain);

            animalObject.Init(config.animalType, movement, foodChain);
            return animalObject;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return new Vector3(
                Random.Range(minInclusive: -5f, maxInclusive: 5f),
                y: 0f,
                Random.Range(minInclusive: -5f, maxInclusive: 5f) // TODO: Config
            );
        }
    }
}

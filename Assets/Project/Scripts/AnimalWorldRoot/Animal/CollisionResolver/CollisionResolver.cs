using AnimalWorld.Animal;
using AnimalWorld.FoodChain;
using UnityEngine;

namespace AnimalWorld.Resolver
{
    public class CollisionResolver
    {
        private readonly AnimalMono _self;
        private readonly IFoodChainBehaviour _foodChain;

        public CollisionResolver(AnimalMono self, IFoodChainBehaviour foodChain)
        {
            _self = self;
            _foodChain = foodChain;

            _self.OnAnimalCollision += OnCollision;
            _self.OnDied += OnDie;
        }

        private void OnDie(IAnimal obj)
        {
            _self.OnDied -= OnDie;
            _self.OnAnimalCollision -= OnCollision;
        }

        private void OnCollision(Collision collision, IAnimal other)
        {
            ICollisionCommand command = _foodChain.Resolve(_self, other);

            command.Execute(_self, collision);
        }
    }
}

using System;
using AnimalWorldRoot.AnimalsConfig;
using AnimalWorldRoot.FoodChain;

namespace AnimalWorldRoot.Animal
{
    public interface IAnimal
    {
        event Action<IAnimal> OnDied;
        AnimalType type { get; }
        IFoodChainBehaviour foodChain { get; }
        void Tick(float deltaTime);
        void Kill();
    }
}

using System;
using AnimalWorld.AnimalsConfig;
using AnimalWorld.FoodChain;

namespace AnimalWorld.Animal
{
    public interface IAnimal
    {
        event Action<IAnimal> OnDied;
        AnimalType type { get; }
        IFoodChainBehaviour foodChain { get; }
        void MoveLifecycle(float deltaTime);
        void Kill();
    }
}

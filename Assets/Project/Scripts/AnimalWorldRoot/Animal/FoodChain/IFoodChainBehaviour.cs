using AnimalWorld.Animal;
using AnimalWorld.Resolver;

namespace AnimalWorld.FoodChain
{
    public interface IFoodChainBehaviour
    {
        ICollisionCommand Resolve(IAnimal self, IAnimal other);
    }
}

using AnimalWorld.Animal;
using AnimalWorld.AnimalsConfig;
using AnimalWorld.Resolver;

namespace AnimalWorld.FoodChain
{
    public class PreyFoodChain : IFoodChainBehaviour
    {
        public ICollisionCommand Resolve(IAnimal self, IAnimal other)
        {
            if (other.type == AnimalType.Predator)
            {
                return new DieCommand();
            }

            return other.type == AnimalType.Prey
                ? new FlyApartCommand(3) // TODO: Config
                : IgnoreCommand.Instance;
        }
    }
}

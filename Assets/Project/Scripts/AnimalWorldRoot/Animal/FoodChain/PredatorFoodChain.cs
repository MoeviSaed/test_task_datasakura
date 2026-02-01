using AnimalWorld.Animal;
using AnimalWorld.AnimalsConfig;
using AnimalWorld.Resolver;

namespace AnimalWorld.FoodChain
{
    public class PredatorFoodChain : IFoodChainBehaviour
    {
        public ICollisionCommand Resolve(IAnimal self, IAnimal other)
        {
            if (self.type == AnimalType.Predator
             && other.type == AnimalType.Predator)
            {
                return self.GetHashCode() < other.GetHashCode()
                    ? new DieCommand()
                    : IgnoreCommand.Instance;
            }

            if (other.type == AnimalType.Prey)
            {
                return new EatOtherCommand(other);
            }

            return IgnoreCommand.Instance;
        }
    }
}

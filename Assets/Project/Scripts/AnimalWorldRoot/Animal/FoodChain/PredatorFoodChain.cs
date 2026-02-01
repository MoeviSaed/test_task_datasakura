using AnimalWorldRoot.Animal;
using AnimalWorldRoot.AnimalsConfig;

namespace AnimalWorldRoot.FoodChain
{
    public class PredatorFoodChain : IFoodChainBehaviour
    {
        public FoodChainResult OnCollide(IAnimal self, IAnimal other)
        {
            if (other == null)
            {
                return FoodChainResult.Ignore;
            }

            if (self.type == AnimalType.Predator
             && other.type == AnimalType.Predator)
            {
                return self.GetHashCode() < other.GetHashCode()
                    ? FoodChainResult.Die
                    : FoodChainResult.Ignore;
            }

            if (other.type == AnimalType.Prey)
            {
                return FoodChainResult.EatOther;
            }

            return FoodChainResult.Ignore;
        }
    }
}

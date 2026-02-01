using AnimalWorldRoot.Animal;
using AnimalWorldRoot.AnimalsConfig;

namespace AnimalWorldRoot.FoodChain
{
    public class PreyFoodChain : IFoodChainBehaviour
    {
        public FoodChainResult OnCollide(IAnimal self, IAnimal other)
        {
            if (other == null)
            {
                return FoodChainResult.Ignore;
            }

            if (other.type == AnimalType.Predator)
            {
                return FoodChainResult.Die;
            }

            return other.type == AnimalType.Prey
                ? FoodChainResult.FlyApart
                : FoodChainResult.Ignore;
        }
    }
}

using AnimalWorldRoot.Animal;

namespace AnimalWorldRoot.FoodChain
{
    public interface IFoodChainBehaviour
    {
        FoodChainResult OnCollide(IAnimal self, IAnimal other);
    }

    public enum FoodChainResult
    {
        Ignore,
        FlyApart,
        Die,
        EatOther
    }
}

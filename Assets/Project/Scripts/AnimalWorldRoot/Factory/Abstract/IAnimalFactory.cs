using AnimalWorldRoot.Animal;
using AnimalWorldRoot.AnimalsConfig;

namespace AnimalWorldRoot.Factory
{
    public interface IAnimalFactory
    {
        IAnimal Create(AnimalConfig config);
    }
}

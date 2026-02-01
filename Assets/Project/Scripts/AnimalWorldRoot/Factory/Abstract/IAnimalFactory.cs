using AnimalWorld.Animal;
using AnimalWorld.AnimalsConfig;

namespace AnimalWorld.Factory
{
    public interface IAnimalFactory
    {
        IAnimal Create(AnimalConfig config);
    }
}

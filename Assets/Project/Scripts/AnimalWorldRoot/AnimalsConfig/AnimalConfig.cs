using AnimalWorld.Animal;
using UnityEngine;

namespace AnimalWorld.AnimalsConfig
{
    [CreateAssetMenu(fileName = "Animal", menuName = "Configs/Animal")]
    public class AnimalConfig : ScriptableObject
    {
        public AnimalMono animalPrefab;
        public AnimalType animalType;
        public MovementType movementType;

        public float speed;
        public float directionChangeInterval;
        public float jumpForce;
    }

    public enum AnimalType
    {
        Prey,
        Predator
    }

    public enum MovementType
    {
        Jump,
        Linear
    }
}

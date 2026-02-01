using AnimalWorldRoot.Animal;
using UnityEngine;

namespace AnimalWorldRoot.AnimalsConfig
{
    [CreateAssetMenu(fileName = "Animal", menuName = "Configs/Animal")]
    public class AnimalConfig : ScriptableObject
    {
        public AnimalView animalPrefab;
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

using UnityEngine;

namespace AnimalWorldRoot.AnimalsConfig
{
    [CreateAssetMenu(fileName = "AnimalsBank", menuName = "Configs/Animals")]
    public class AnimalsConfig : ScriptableObject
    {
        public AnimalConfig[] animals;
    }
}

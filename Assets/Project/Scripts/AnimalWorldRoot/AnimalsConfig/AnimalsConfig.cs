using UnityEngine;

namespace AnimalWorld.AnimalsConfig
{
    [CreateAssetMenu(fileName = "AnimalsBank", menuName = "Configs/Animals")]
    public class AnimalsConfig : ScriptableObject
    {
        public AnimalConfig[] animals;
    }
}

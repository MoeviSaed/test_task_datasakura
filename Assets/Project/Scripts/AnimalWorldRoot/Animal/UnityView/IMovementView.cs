using UnityEngine;

namespace AnimalWorldRoot.Animal
{
    public interface IMovementView
    {
        Vector3 rigidbodyPosition { get; set; }
        void AddForce(Vector3 force);
    }
}

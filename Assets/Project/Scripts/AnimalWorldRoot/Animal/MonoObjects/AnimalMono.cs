using System;
using AnimalWorld.AnimalsConfig;
using AnimalWorld.FoodChain;
using AnimalWorld.MovementStrategy;
using UnityEngine;

namespace AnimalWorld.Animal
{
    public class AnimalMono
        : MonoBehaviour,
          IMovementView,
          IAnimal
    {
        public event Action<IAnimal> OnDied;
        public event Action<Collision, IAnimal> OnAnimalCollision;
        public AnimalType type { get; private set; }
        public IFoodChainBehaviour foodChain { get; private set; }
        public Rigidbody rigidbody => _rigidbody;

        [SerializeField] private Rigidbody _rigidbody;
        private IMovementStrategy _movement;
        private bool _isDead;

        public void Init(AnimalType type, IMovementStrategy movement, IFoodChainBehaviour foodChain)
        {
            this.type = type;
            _movement = movement;
            this.foodChain = foodChain;
        }

        public void MoveLifecycle(float deltaTime)
        {
            if (_isDead)
            {
                return;
            }

            _movement.Tick(deltaTime);
        }

        public void Kill()
        {
            if (_isDead)
            {
                return;
            }

            _isDead = true;
            OnDied?.Invoke(this);

            Destroy(gameObject); //TODO: Implement poolObject
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IAnimal otherAnimal))
            {
                OnAnimalCollision?.Invoke(collision, otherAnimal);
            }
        }
    }
}

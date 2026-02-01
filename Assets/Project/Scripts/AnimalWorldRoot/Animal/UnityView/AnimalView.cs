using System;
using AnimalWorldRoot.AnimalsConfig;
using AnimalWorldRoot.FoodChain;
using AnimalWorldRoot.MovementStrategy;
using UnityEngine;

namespace AnimalWorldRoot.Animal
{
    public class AnimalView
        : MonoBehaviour,
          IMovementView,
          IAnimal
    {
        public event Action<IAnimal> OnDied;

        public AnimalType type { get; private set; }
        public IFoodChainBehaviour foodChain { get; private set; }

        public Vector3 rigidbodyPosition
        {
            get => _rigidbody.position;
            set => _rigidbody.position = value;
        }

        [SerializeField] private Rigidbody _rigidbody;

        private IMovementStrategy _movement;
        private bool _isDead;

        public void Tick(float deltaTime)
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

        public void AddForce(Vector3 force)
        {
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var otherAnimal = collision.gameObject.GetComponent<IAnimal>();

            if (otherAnimal == null)
            {
                return;
            }

            FoodChainResult result = foodChain.OnCollide(this, otherAnimal);

            switch (result)
            {
                case FoodChainResult.Ignore:

                    break;

                case FoodChainResult.Die:
                    Kill();
                    break;

                case FoodChainResult.EatOther:
                    otherAnimal.Kill();
                    break;

                case FoodChainResult.FlyApart:
                    Vector3 normal = collision.contacts[0].normal;
                    normal.y = 0.5f;
                    AddForce(normal.normalized * 3f);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Init(AnimalType type, IMovementStrategy movement, IFoodChainBehaviour foodChain)
        {
            this.type = type;
            _movement = movement;
            this.foodChain = foodChain;
        }
    }
}

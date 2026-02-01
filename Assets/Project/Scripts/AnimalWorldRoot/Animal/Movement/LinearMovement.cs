using AnimalWorldRoot.Animal;
using Modules.ScreenBounds;
using UnityEngine;

namespace AnimalWorldRoot.MovementStrategy
{
    public class LinearMovement : IMovementStrategy
    {
        private readonly IMovementView _view;
        private readonly float _speed;
        private readonly IScreenBounds _bounds;
        private readonly float _directionChangeInterval;

        private Vector3 _direction;
        private float _directionTimer;

        public LinearMovement(IMovementView view, Vector3 direction, float speed, float directionChangeInterval,
            IScreenBounds bounds)
        {
            _view = view;
            _direction = direction.normalized;
            _speed = speed;
            _bounds = bounds;
            _directionChangeInterval = directionChangeInterval;
        }

        public void Tick(float deltaTime)
        {
            _directionTimer -= deltaTime;

            if (_directionTimer <= 0f)
            {
                ChangeDirection();
                _directionTimer = _directionChangeInterval;
            }

            Vector3 nextPosition = _view.rigidbodyPosition + _direction * _speed * deltaTime;

            if (_bounds.IsOutOfBounds(nextPosition))
            {
                _direction = _bounds.GetReturnDirection(nextPosition);
                _directionTimer = _directionChangeInterval; // сброс, чтобы не дергалось
                nextPosition = _view.rigidbodyPosition + _direction * _speed * deltaTime;
            }

            _view.rigidbodyPosition = nextPosition;
        }

        private void ChangeDirection()
        {
            Vector3 newDir = Random.insideUnitSphere;
            newDir.y = 0f;

            if (newDir.sqrMagnitude < 0.01f)
            {
                newDir = _direction;
            }

            _direction = newDir.normalized;
        }
    }
}

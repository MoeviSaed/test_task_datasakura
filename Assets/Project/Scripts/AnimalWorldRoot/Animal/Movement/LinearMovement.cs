using AnimalWorld.Animal;
using Modules.ScreenBounds;
using UnityEngine;

namespace AnimalWorld.MovementStrategy
{
    public class LinearMovement : IMovementStrategy
    {
        private readonly IMovementView _view;
        private readonly float _speed;
        private readonly IScreenBounds _bounds;
        private readonly float _directionChangeInterval;

        private Vector3 _startDirection;
        private float _directionTimer;

        public LinearMovement(IMovementView view, Vector3 direction, float speed, float directionChangeInterval,
            IScreenBounds bounds)
        {
            _view = view;
            _startDirection = direction.normalized;
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

            Vector3 nextPosition = _view.rigidbody.position + _startDirection * _speed * deltaTime;

            if (_bounds.IsOutOfBounds(nextPosition))
            {
                _startDirection = _bounds.GetReturnDirection(nextPosition);
                _directionTimer = _directionChangeInterval; // сброс, чтобы не дергалось
                nextPosition = _view.rigidbody.position + _startDirection * _speed * deltaTime;
            }

            _view.rigidbody.position = nextPosition;
        }

        private void ChangeDirection()
        {
            Vector3 newDir = Random.insideUnitSphere;
            newDir.y = 0f;

            if (newDir.sqrMagnitude < 0.01f)
            {
                newDir = _startDirection;
            }

            _startDirection = newDir.normalized;
        }
    }
}

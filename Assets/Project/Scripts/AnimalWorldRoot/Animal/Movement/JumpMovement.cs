using AnimalWorld.Animal;
using Modules.ScreenBounds;
using UnityEngine;

namespace AnimalWorld.MovementStrategy
{
    public class JumpMovement : IMovementStrategy
    {
        private readonly IMovementView _movementView;
        private readonly float _jumpForce;
        private readonly float _interval;
        private readonly IScreenBounds _screenBounds;

        private float _timer;

        public JumpMovement(IMovementView movementView, float jumpForce, float interval, IScreenBounds screenBounds)
        {
            _movementView = movementView;
            _jumpForce = jumpForce;
            _interval = interval;
            _screenBounds = screenBounds;
        }

        public void Tick(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer > 0f)
            {
                return;
            }

            _timer = _interval;

            Vector3 dir = GetJumpDirection();
            _movementView.rigidbody.AddForce(dir * _jumpForce, ForceMode.Impulse);
        }

        private Vector3 GetJumpDirection()
        {
            if (_screenBounds.IsOutOfBounds(_movementView.rigidbody.position))
            {
                Vector3 returnDir = _screenBounds.GetReturnDirection(_movementView.rigidbody.position);

                return new Vector3(returnDir.x, y: _jumpForce, returnDir.z).normalized;
            }

            Vector3 dir = Random.insideUnitSphere;
            dir.y = _jumpForce;

            return dir.normalized;
        }
    }
}

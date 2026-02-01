using AnimalWorldRoot.Animal;
using Modules.ScreenBounds;
using UnityEngine;

namespace AnimalWorldRoot.MovementStrategy
{
    public class JumpMovement : IMovementStrategy
    {
        private readonly IMovementView _view;
        private readonly float _jumpForce;
        private readonly float _interval;
        private readonly IScreenBounds _screenBounds;

        private float _timer;

        public JumpMovement(IMovementView view, float jumpForce, float interval, IScreenBounds screenBounds)
        {
            _view = view;
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
            _view.AddForce(dir * _jumpForce);
        }

        private Vector3 GetJumpDirection()
        {
            if (_screenBounds.IsOutOfBounds(_view.rigidbodyPosition))
            {
                Vector3 returnDir = _screenBounds.GetReturnDirection(_view.rigidbodyPosition);

                return new Vector3(returnDir.x, y: 1f, returnDir.z).normalized;
            }

            Vector3 dir = Random.insideUnitSphere;
            dir.y = 5f;

            return dir.normalized;
        }
    }
}

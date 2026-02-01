using UnityEngine;

namespace Modules.ScreenBounds
{
    public class CameraScreenBounds : IScreenBounds
    {
        private readonly Camera _camera;

        public CameraScreenBounds(Camera camera)
        {
            _camera = camera;
        }

        public bool IsOutOfBounds(Vector3 worldPosition)
        {
            Vector3 viewport = _camera.WorldToViewportPoint(worldPosition);

            return viewport.x < 0f || viewport.x > 1f || viewport.y < 0f || viewport.y > 1f;
        }

        public Vector3 GetReturnDirection(Vector3 fromPosition)
        {
            Vector3 viewport = _camera.WorldToViewportPoint(fromPosition);
            Vector3 centerWorld = _camera.ViewportToWorldPoint(new Vector3(x: 0.5f, y: 0.5f, viewport.z));

            return (centerWorld - fromPosition).normalized;
        }
    }
}

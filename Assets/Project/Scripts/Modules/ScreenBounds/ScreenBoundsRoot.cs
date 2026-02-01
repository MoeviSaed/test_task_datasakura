using UnityEngine;

namespace Modules.ScreenBounds
{
    public class ScreenBoundsRoot
    {
        public IScreenBounds screenBounds { get; private set; }

        public ScreenBoundsRoot(Camera camera)
        {
            screenBounds = new CameraScreenBounds(camera);
        }
    }
}

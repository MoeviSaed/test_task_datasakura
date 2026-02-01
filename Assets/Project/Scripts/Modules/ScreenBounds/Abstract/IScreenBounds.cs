using UnityEngine;

namespace Modules.ScreenBounds
{
    public interface IScreenBounds
    {
        bool IsOutOfBounds(Vector3 worldPosition);
        Vector3 GetReturnDirection(Vector3 fromPosition);
    }
}

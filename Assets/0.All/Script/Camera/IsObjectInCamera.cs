using UnityEngine;

public class IsObjectInCamera : MonoBehaviour
{
    bool _isObjectInCamera;
    public bool IsObjectInCameraState
    {
        get
        {
            return _isObjectInCamera;
        }
    }

    void OnBecameVisible()
    {
        _isObjectInCamera = true;
    }

    void OnBecameInvisible()
    {
        _isObjectInCamera = false;
    }
}

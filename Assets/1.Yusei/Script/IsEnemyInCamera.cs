using UnityEngine;

public class IsEnemyInCamera : MonoBehaviour
{
    bool _isEnemyInCamera;
    public bool IsEnemyInCameraState
    {
        get
        {
            return _isEnemyInCamera;
        }
    }

    void OnBecameVisible()
    {
        _isEnemyInCamera = true;
    }

    void OnBecameInvisible()
    {
        _isEnemyInCamera = false;
    }
}

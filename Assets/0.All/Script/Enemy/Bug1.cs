using UnityEngine;

public class Bug1 : MonoBehaviour
{
    //虫１
    //Move：空中で反復横移動
    Rigidbody2D _rb;
    IsObjectInCamera _isObjectInCamera;
    [SerializeField, Tooltip("エネミーのスピード")] float _moveSpeed;
    float _time;
    [SerializeField] float _intervalTime;

    void Start()
    {
        SetUp();
    }

    void Update()
    {
        if (!_isObjectInCamera.IsObjectInCameraState)
            return;
        Active();
    }

    void SetUp()
    {
        _isObjectInCamera = GetComponent<IsObjectInCamera>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Active()
    {
        if (GameManager.Instance.IsPlayerHide && GameManager.Instance.IsMind)
            return;
        _rb.velocity = Vector2.right * _moveSpeed;
        _time += Time.deltaTime;
        if(_time > _intervalTime)
        {
            _time = 0;
            _moveSpeed = _moveSpeed * -1;
        }
    }
}

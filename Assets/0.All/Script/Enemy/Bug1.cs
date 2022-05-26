using UnityEngine;

public class Bug1 : MonoBehaviour
{
    //虫１
    //Move：空中で反復横移動
    GameObject _player;
    Transform _playerTransform;
    Rigidbody2D _rb;
    bool _isActive;
    IsObjectInCamera _isObjectInCamera;
    [SerializeField, Tooltip("プレイヤーを検知する範囲")] float _activeRange;
    [SerializeField, Tooltip("エネミーのスピード")] float _moveSpeed;
    [SerializeField, Tooltip("検知範囲のLayerを表示")] bool _layerDebug;
    Vector2 _dir;

    void Start()
    {
        SetUp();
    }

    void Update()
    {
        LayerDebug();
        if (!_isObjectInCamera.IsObjectInCameraState)
            return;
        Active();
    }

    void SetUp()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _isObjectInCamera = GetComponent<IsObjectInCamera>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void LayerDebug()
    {
        if (!_layerDebug)
            return;
        Debug.DrawRay(transform.position, _dir, Color.red, _activeRange);
    }

    void Active()
    {
        if (GameManager.Instance.IsPlayerHide)
            return;
        Vector3 velocity = _dir * _moveSpeed;
        _rb.AddForce(velocity * Time.deltaTime);
    }
}

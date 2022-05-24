using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    //蜘蛛
    //Idol：壁や天井、床を巡回する
    //Move：プレイヤーが近くなるとスピードアップ

    GameObject _player;
    Transform _playerTransform;
    Rigidbody2D _rb;
    bool _isActive;
    float _moveSpeed;
    IsObjectInCamera _isObjectInCamera;
    [SerializeField, Tooltip("プレイヤーを検知する範囲")] float _activeRange;
    [SerializeField, Tooltip("エネミーのスピード")] float _defaultMoveSpeed;
    [SerializeField, Tooltip("アクティブ状態のエネミーのスピード")] float _activeMoveSpeed;
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
        Range();
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

    void Range()
    {
        _playerTransform = _player.transform;
        float range = Vector2.Distance(_playerTransform.position, transform.position);
        if (range < _activeRange)
        {
            _dir = _playerTransform.position - transform.position;
            _dir = _dir.normalized;
            _dir.y = 0;
            _isActive = true;
        }
        else
        {
            _isActive = false;
        }
    }

    void Active()
    {
        //壁移動の処理


        if (!_isActive && GameManager.Instance.IsPlayerHide)
        {
            _moveSpeed = _defaultMoveSpeed;
        }
        else
        {
            _moveSpeed = _activeMoveSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    //������
    //Idol�F�󒆂Ŕ������ړ�
    //Move�F���͈͓��ɓ����Ă�����v���C���[�̕��ֈړ�

    GameObject _player;
    Transform _playerTransform;
    Rigidbody2D _rb;
    bool _isActive;
    IsObjectInCamera _isObjectInCamera;
    [SerializeField, Tooltip("�v���C���[�����m����͈�")] float _activeRange;
    [SerializeField, Tooltip("�G�l�~�[�̃X�s�[�h")] float _moveSpeed;
    [SerializeField, Tooltip("���m�͈͂�Layer��\��")] bool _layerDebug;
    Vector2 _dir;
    [SerializeField] Animator _anim;
    float _time;
    [SerializeField] float _intervalTime = 5f;

    void Start()
    {
        SetUp();
    }

    void Update()
    {
        LayerDebug();
        Anim();
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
        Debug.DrawRay(transform.position, Vector2.right * _activeRange, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * _activeRange, Color.red);
    }

    void Anim()
    {
        _anim.SetBool("anim", _isActive);
    }

    void Range()
    {
        _playerTransform = _player.transform;
        float range = Vector2.Distance(_playerTransform.position, transform.position);
        if (range < _activeRange)
        {
            _isActive = true;
        }
        else
        {
            _isActive = false;
        }
    }

    void Active()
    {
        if(!_isActive)
        {
            _rb.velocity = Vector2.right * _moveSpeed;
            _time += Time.deltaTime;
        }
        
        if (_time > _intervalTime)
        {
            _time = 0;
            _moveSpeed = _moveSpeed * -1;
        }
        if (!_isActive || GameManager.Instance.IsPlayerHide)
        {
            return;
        }
        _dir = _playerTransform.position - transform.position;
        float move = _moveSpeed;
        if (_dir.x < 0)
        {
            move = _moveSpeed * -1;
        }
        else
        {
            move = _moveSpeed;
        }
        _rb.velocity = new Vector2(move, _rb.velocity.y);
    }
}

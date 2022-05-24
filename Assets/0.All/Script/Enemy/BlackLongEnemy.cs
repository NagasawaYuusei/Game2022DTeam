using UnityEngine;

public class BlackLongEnemy : MonoBehaviour
{
    //������
    //Idol�F�v���C���[�����͈͓��ɓ����Ă���܂őҋ@
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

    void Start()
    {
        SetUp();
    }

    void Update()
    {
        LayerDebug();
        if(!_isObjectInCamera.IsObjectInCameraState)
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
        if(range < _activeRange)
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
        if (!_isActive && GameManager.Instance.IsPlayerHide)
            return;
        Vector3 velocity = _dir * _moveSpeed;
        _rb.AddForce(velocity * Time.deltaTime);
    }
}
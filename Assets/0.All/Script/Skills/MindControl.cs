using UnityEngine;
using Cinemachine;

public class MindControl : ObjectSelectContoroller
{
    bool _isNowControl;
    bool on;
    [SerializeField] CinemachineVirtualCamera _cvc;
    [Header("���삷��G�l�~�[���i�[")]
    [Tooltip("���]�����G�l�~�[")] GameObject _mindEnemy;
    [Tooltip("�G�l�~�[��Rigidbody")] Rigidbody2D _enemyRb;
    [Tooltip("�G�l�~�[��Vector2")] Vector2 _enemyVec;

    [Header("�G�l�~�[�̈ړ����x")]
    [SerializeField, Tooltip("�G�l�~�[�̈ړ����x")] float _enemySpeed;

    [SerializeField, Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isMindControl = true;
    public bool IsMindControl { get { return _isMindControl; } set { _isMindControl = value; } }
    public bool IsNowControl { get { return _isNowControl; } }



    private static MindControl instance;
    public static MindControl Instance
    {
        get
        {
            if (!instance)
            {
                instance = (MindControl)FindObjectOfType(typeof(MindControl));
                if (!instance)
                {
                    Debug.LogError("nothing");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
    }



    void Update()
    {
        EnemyMindControl();
    }

    /// <summary>
    /// InputSystem
    /// �G�𑀍삷��
    /// </summary>
    void EnemyMindControl()
    {
        if (!_isMindControl) return;
        if (InputSystemManager.Instance._isSkill && !_isNowControl)
        {
            Select("Enemy");
            _mindEnemy = First();
            _enemyRb = _mindEnemy.GetComponent<Rigidbody2D>();
            _cvc.Follow = _mindEnemy.transform;
            _isNowControl = true;
            InputSystemManager.Instance._isSkill = false;
        }
        else if(InputSystemManager.Instance._isSkill && _isNowControl)
        {
            _cvc.Follow = gameObject.transform;
            _isNowControl = false;
            _enemyRb.velocity = Vector2.zero;
            InputSystemManager.Instance._isSkill = false;
        }

        if(_isNowControl)
        {
            EnemyMove();
            if(InputSystemManager.Instance._vec2.y > 0 && !on)
            {
                _mindEnemy = Change(1);
                _enemyRb = _mindEnemy.GetComponent<Rigidbody2D>();
                _cvc.Follow = _mindEnemy.transform;
                on = true;
            }
            else if(InputSystemManager.Instance._vec2.y < 0 && !on)
            {
                _mindEnemy = Change(-1);
                _enemyRb = _mindEnemy.GetComponent<Rigidbody2D>();
                _cvc.Follow = _mindEnemy.transform;
                on = true;
            }
            else if(InputSystemManager.Instance._vec2.y == 0 && on)
            {
                on = false;
            }
        }
    }

    void EnemyMove()
    {
        _enemyRb.velocity = new Vector2(InputSystemManager.Instance._vec1.x * _enemySpeed, _enemyRb.velocity.y);
    }
}

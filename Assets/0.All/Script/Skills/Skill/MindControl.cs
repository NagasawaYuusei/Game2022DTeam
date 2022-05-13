using UnityEngine;
using Cinemachine;

public class MindControl : ObjectSelectContoroller
{
    bool _isCurrentControl;
    bool on;
    [Tooltip("シネマシン")] CinemachineVirtualCamera _cvc;
    [Header("操作するエネミーを格納")]
    [Tooltip("洗脳したエネミー")] GameObject _mindEnemy;
    [Tooltip("エネミーのRigidbody")] Rigidbody2D _enemyRb;
    [Tooltip("エネミーのVector2")] Vector2 _enemyVec;

    [Header("エネミーの移動速度")]
    [SerializeField, Tooltip("エネミーの移動速度")] float _enemySpeed;

    [SerializeField, Tooltip("このスキルが使えるかどうか")] bool _isMindControl = true;
    public bool IsMindControl { get { return _isMindControl; } set { _isMindControl = value; } }
    public bool IsCurrentControl { get { return _isCurrentControl; } }



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

    void Start()
    {
        _cvc = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {
        EnemyMindControl();
    }

    /// <summary>
    /// InputSystem
    /// 敵を操作する
    /// </summary>
    void EnemyMindControl()
    {
        if (!_isMindControl) return;
        if (InputSystemManager.Instance._isSkill && !_isCurrentControl)
        {
            Select("Enemy");
            _mindEnemy = First();
            if(_mindEnemy)
            {
                _enemyRb = _mindEnemy.GetComponent<Rigidbody2D>();
                _cvc.Follow = _mindEnemy.transform;
                _isCurrentControl = true;
            }
            InputSystemManager.Instance._isSkill = false;
        }
        else if(InputSystemManager.Instance._isSkill && _isCurrentControl)
        {
            _cvc.Follow = GameObject.FindGameObjectWithTag("Player").transform;
            _isCurrentControl = false;
            _enemyRb.velocity = Vector2.zero;
            InputSystemManager.Instance._isSkill = false;
        }

        if(_isCurrentControl)
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

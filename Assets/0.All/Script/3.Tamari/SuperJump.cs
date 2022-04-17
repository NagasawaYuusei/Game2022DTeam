using UnityEngine;

public class SuperJump : MonoBehaviour
{
    int _jumpCount;
    GameObject _player;
    [Header("多段ジャンプの設定")]
    [SerializeField] int _maxJumpCount;

    [Tooltip("このスキルが使えるかどうか")] bool _isJumped = true;
    public bool IsSuperJump { get { return _isJumped; } set { _isJumped = value; } }
    public int JumpCount { set { _jumpCount = value; } }
    [SerializeField] string GroundTagName;

    private static SuperJump instance;
    public static SuperJump Instance
    {
        get
        {
            if (!instance)
            {
                instance = (SuperJump)FindObjectOfType(typeof(SuperJump));
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
        _player = GameObject.FindGameObjectWithTag("Player");
        _jumpCount = 0;
    }

    void Update()
    {
        Jump();
    }

    /// <summary>
    /// InputSystem
    /// 多段ジャンプ
    /// </summary>
    /// <param name="context"></param>
    void Jump()
    {
        if (_isJumped && _jumpCount < _maxJumpCount && InputSystemManager.Instance._isJump)
        {
            _jumpCount++;
            _player.GetComponent<PlayerController>().JumpMethod();
            InputSystemManager.Instance._isJump = false;
        }
        if(_jumpCount == _maxJumpCount)
        {
            InputSystemManager.Instance._isJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
        }
    }
}

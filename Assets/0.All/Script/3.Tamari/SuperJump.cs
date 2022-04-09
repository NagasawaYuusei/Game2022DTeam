using UnityEngine;

public class SuperJump : MonoBehaviour
{
    SkillClass _sc = new SkillClass(3);
    int _jumpCount;
    [Header("Playerの設定")]
    [SerializeField] GameObject _player;
    [Header("多段ジャンプの設定")]
    [SerializeField] int _maxJumpCount;

    [Tooltip("このスキルが使えるかどうか")] bool _isJumped = true;
    public bool IsSuperJump { get { return _isJumped; } set { _isJumped = value; } }
    public int JumpCount { set { _jumpCount = value; } }
    [SerializeField] string GroundTagName;
    void Start()
    {
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

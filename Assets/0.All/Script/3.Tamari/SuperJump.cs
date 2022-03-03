using UnityEngine;
using UnityEngine.InputSystem;

public class SuperJump : MonoBehaviour
{
    int _jumpCount;
    [Header("Playerの設定")]
    [SerializeField] GameObject _player;
    [Header("多段ジャンプの設定")]
    [SerializeField] int _maxJumpCount;

    [Tooltip("このスキルが使えるかどうか")] bool _isJumped = true;
    public bool IsSuperJump { get { return _isJumped; } set { _isJumped = value; } }
    public int JumpCount { set { _jumpCount = value; } }
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
        if (_jumpCount < _maxJumpCount && _isJumped && InputSystemManager.Instance._isJump
            && _player.GetComponent<PlayerController>().IsGrounded())
        {
            _jumpCount++;
            _player.GetComponent<PlayerController>().PlayerJump();
        }

    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class SuperJump : MonoBehaviour
{
    int _jumpCount;
    [Header("Player�̐ݒ�")]
    [SerializeField] GameObject _player;
    [Header("���i�W�����v�̐ݒ�")]
    [SerializeField] int _maxJumpCount;

    [Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isJumped = true;
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
    /// ���i�W�����v
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

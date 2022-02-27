using UnityEngine;
using UnityEngine.InputSystem;

public class SuperJump : MonoBehaviour
{
    GameObject _player;
    [Header("���i�W�����v�̐ݒ�")]
    [SerializeField] int _jumpCount;
    [SerializeField] int _maxJumpCount;

    [Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isJumped = true;
    public bool IsSuperJump { get { return _isJumped; } set { _isJumped = value; } }
    void Start()
    {
        _player = GameObject.Find("Player");
        _jumpCount = 0;
    }
    /// <summary>
    /// Ground�ɒ�������JumpCount��0�ɂ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
        }
    }

    /// <summary>
    /// InputSystem
    /// ���i�W�����v
    /// </summary>
    /// <param name="context"></param>
    public void PlayerSuperJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_isJumped && _jumpCount < _maxJumpCount)
            {
                Debug.Log("jump");
                _jumpCount++;
                _player.GetComponent<TestPlayerCon>().PlayerJump();
            }
        }
    }
}

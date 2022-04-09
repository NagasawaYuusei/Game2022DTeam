using UnityEngine;

public class SuperJump : MonoBehaviour
{
    SkillClass _sc = new SkillClass(3);
    int _jumpCount;
    [Header("Player�̐ݒ�")]
    [SerializeField] GameObject _player;
    [Header("���i�W�����v�̐ݒ�")]
    [SerializeField] int _maxJumpCount;

    [Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isJumped = true;
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
    /// ���i�W�����v
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

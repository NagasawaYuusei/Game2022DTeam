using UnityEngine;
using UnityEngine.InputSystem;

public class SuperJump : MonoBehaviour
{
    GameObject _player;
    [Header("多段ジャンプの設定")]
    [SerializeField] int _jumpCount;
    [SerializeField] int _maxJumpCount;

    [Tooltip("このスキルが使えるかどうか")] bool _isJumped = true;
    public bool IsSuperJump { get { return _isJumped; } set { _isJumped = value; } }
    void Start()
    {
        _player = GameObject.Find("Player");
        _jumpCount = 0;
    }
    /// <summary>
    /// Groundに着いたらJumpCountを0にする
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
    /// 多段ジャンプ
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

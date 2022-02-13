using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーコントローラーテスト
/// </summary>
public class TestPlayerCon : MonoBehaviour
{
    [Tooltip("プレイヤーのRb")]Rigidbody2D _rb;
    [Tooltip("InputSystemの移動入力")]Vector2 _playerVec;
    [Header("設定項目")]
    [Tooltip("移動速度"), SerializeField] float _moveSpeed;
    [Tooltip("ジャンプスピード"), SerializeField] float _jumpSpeed;

    void Start()
    {
        StartSetUp();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    /// <summary>
    /// Startでのセットアップ
    /// </summary>
    void StartSetUp()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    void PlayerMove()
    {
        _rb.velocity = new Vector2(_moveSpeed * _playerVec.x, _rb.velocity.y);
    }

    /// <summary>
    /// プレイヤーのジャンプ処理
    /// </summary>
    void PlayerJump()
    {
        _rb.AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    /// <summary>
    /// InputSystem
    /// 移動
    /// </summary>
    /// <param name="context"></param>
    public void PlayerMoveInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _playerVec = context.ReadValue<Vector2>();
        }
        else if(context.canceled)
        {
            _playerVec = Vector2.zero;
        }
    }

    /// <summary>
    /// InputSystem
    /// ジャンプ
    /// </summary>
    /// <param name="context"></param>
    public void PlayerJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            PlayerJump();
        }
    }
}

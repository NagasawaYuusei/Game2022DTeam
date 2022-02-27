using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーコントローラーテスト
/// </summary>
public class TamariTestPlayerCon : MonoBehaviour
{
    [Tooltip("プレイヤーのRb")]Rigidbody2D _rb;
    [Tooltip("InputSystemの移動入力")]Vector2 _playerVec;
    [Header("設定項目")]
    [Tooltip("移動速度"), SerializeField] float _moveSpeed;
    [Tooltip("ジャンプスピード"), SerializeField] float _jumpSpeed;
    [SerializeField] float _shakeTime;

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
    public void PlayerJump()
    {
        _rb.velocity = Vector2.up * _jumpSpeed;
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
            StartCoroutine(Vibration(1, 1, _shakeTime));
        }
    }

    private static IEnumerator Vibration
    (
        float lowFrequency, // 低周波（左）モーターの強さ（0.0 ～ 1.0）
        float highFrequency, // 高周波（右）モーターの強さ（0.0 ～ 1.0）
        float time
    )
    {
        var gamepad = Gamepad.current;
        gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
        yield return new WaitForSeconds(time); // 1 秒間振動させる
        gamepad.SetMotorSpeeds(0, 0);
    }
}

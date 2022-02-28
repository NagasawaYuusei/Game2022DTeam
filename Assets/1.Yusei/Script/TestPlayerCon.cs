using System.Collections;
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
    [SerializeField] float _shakeTime;
    [SerializeField] float _groundLength;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] bool _isGroundedVisible;
 
    void Start()
    {
        StartSetUp();
    }

    private void Update()
    {
        IsGrounded();
        PlayerJump();
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
        _rb.velocity = new Vector2(_moveSpeed * InputSystemManager.Instance._vec1.x, _rb.velocity.y);
    }

    /// <summary>
    /// プレイヤーのジャンプ処理
    /// </summary>
    void PlayerJump()
    {
        if(InputSystemManager.Instance._isJump &&IsGrounded())
        {
            _rb.velocity = Vector2.up * _jumpSpeed;
            StartCoroutine(Vibration(1, 1, _shakeTime));
        }
    }

    bool IsGrounded()
    {
        bool jumpray = Physics2D.Raycast(transform.position, Vector2.down, _groundLength, _layerMask);
        Debug.DrawRay(transform.position, Vector2.down * _groundLength);
        return jumpray;
    }

    private static IEnumerator Vibration
    (
        float lowFrequency, // 低周波（左）モーターの強さ（0.0 ～ 1.0）
        float highFrequency, // 高周波（右）モーターの強さ（0.0 ～ 1.0）
        float time
    )
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
            yield return new WaitForSeconds(time); // 1 秒間振動させる
            gamepad.SetMotorSpeeds(0, 0);
        }
    }
}

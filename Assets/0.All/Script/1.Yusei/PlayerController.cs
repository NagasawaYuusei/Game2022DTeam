using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーのRb")] Rigidbody2D _rb;
    [Header("設定項目")]
    [Tooltip("移動速度"), SerializeField] float _moveSpeed;
    [Tooltip("ジャンプスピード"), SerializeField] float _jumpSpeed;
    [Tooltip("ジャンプ時のコントローラー振動"), SerializeField] float _shakeTime;
    [Tooltip("設置判定距離"), SerializeField] float _groundLength;
    [Tooltip("地面のレイヤー"), SerializeField] LayerMask _layerMask;
    [Tooltip("設置判定をオンにするかどうか"), SerializeField] bool _isGroundedVisible;

    bool _on;
    GameObject _mc;
    GameObject _pc;
    GameObject _sj;
         
    public bool On { set { _on = value; } }

    void Start()
    {
        _mc = SkillManager.Instance.transform.Find("1.Psychokinesis").gameObject;
        _pc = SkillManager.Instance.transform.Find("2.MindContorol").gameObject;
        _sj = SkillManager.Instance.transform.Find("3.SuperJump").gameObject;
        StartSetUp();
    }

    void Update()
    {
        PlayerJump();
        Visible();
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
    /// 設置判定の可視化
    /// </summary>
    void Visible()
    {
        if (_isGroundedVisible)
        {
            IsGrounded();
        }
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    void PlayerMove()
    {
        if (_mc.activeSelf)
        {
            if(_mc.GetComponent<Psychokinesis>().IsNowControl)
            {
                _rb.velocity = Vector2.zero;
                return;
            }
        }

        if (_pc.activeSelf)
        {
            if (_pc.GetComponent<Psychokinesis>().IsNowControl)
            {
                _rb.velocity = Vector2.zero;
                return;
            }
        }
        _rb.velocity = new Vector2(InputSystemManager.Instance._vec1.x * _moveSpeed, _rb.velocity.y);
    }

    /// <summary>
    /// プレイヤーのジャンプ処理 改善予定
    /// </summary>
    void PlayerJump()
    {
        if (_mc.activeSelf)
        {
            if (!_mc.GetComponent<Psychokinesis>().IsNowControl)
            {
                return;
            }
        }
        if (_sj.activeSelf) return;

        if (InputSystemManager.Instance._isJump && IsGrounded())
        {
            JumpMethod();
        }
    }

    public void JumpMethod()
    {
        _rb.velocity = Vector2.up * _jumpSpeed;
        StartCoroutine(Vibration(1, 1, _shakeTime));
    }

    /// <summary>
    /// 設置判定
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        bool jumpray = Physics2D.Raycast(transform.position, Vector2.down, _groundLength, _layerMask);
        Debug.DrawRay(transform.position, Vector2.down * _groundLength);
        if (!jumpray && !_sj.activeSelf) InputSystemManager.Instance._isJump = false;
        return jumpray;
    }

    /// <summary>
    /// コントローラー振動
    /// </summary>
    /// <param name="lowFrequency"></param>
    /// <param name="highFrequency"></param>
    /// <param name="time"></param>
    /// <returns></returns>
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

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    protected override bool dontDestroyOnLoad { get { return false; } }
    [Tooltip("プレイヤーのRb")] Rigidbody2D _rb;
    [Header("設定項目")]
    [Tooltip("移動速度"), SerializeField] float _moveSpeed;
    [Tooltip("ジャンプスピード"), SerializeField] float _jumpSpeed;
    [Tooltip("ジャンプ時のコントローラー振動"), SerializeField] float _shakeTime;
    [Tooltip("設置判定距離"), SerializeField] float _groundLength;
    [Tooltip("地面のレイヤー"), SerializeField] LayerMask _layerMask;
    [Tooltip("設置判定をオンにするかどうか"), SerializeField] bool _isGroundedVisible;

    bool _on;
    [Tooltip("MindCon")] GameObject _mc;
    [Tooltip("Psychokinesis")] GameObject _pc;
    [Tooltip("SuperJump")] GameObject _sj;
    GameObject _bl;
    GameObject _gh;

    public bool On { set { _on = value; } }
    public float JumpSpeed { get { return _jumpSpeed; } }

    void Start()
    {
        _pc = SkillManager.Instance.transform.Find("1.Psychokinesis").gameObject;
        _mc = SkillManager.Instance.transform.Find("2.MindContorol").gameObject;
        _sj = SkillManager.Instance.transform.Find("3.SuperJump").gameObject;
        _bl = SkillManager.Instance.transform.Find("8.Blink").gameObject;
        _gh = SkillManager.Instance.transform.Find("7.GrapringHook" ).gameObject;
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
        if (_mc.activeSelf || _pc.activeSelf)
        {
            if(_mc.activeSelf)
            {
                if (_mc.GetComponent<MindControl>().IsCurrentControl)
                {
                    _rb.velocity = Vector2.zero;
                    return;
                }
            }
            
            if(_pc.activeSelf)
            {
                if (_pc.GetComponent<Psychokinesis>().IsNowControl)
                {
                    _rb.velocity = Vector2.zero;
                    return;
                }
            }
        }
        if (_bl.activeSelf && InputSystemManager.Instance._isSkill) return;
        if (_gh.activeSelf && InputSystemManager.Instance._isSkill) return;

        _rb.velocity = new Vector2(InputSystemManager.Instance._vec1.x * _moveSpeed, _rb.velocity.y);
    }

    /// <summary>
    /// プレイヤーのジャンプ処理 改善予定
    /// </summary>
    void PlayerJump()
    {
        if (_mc.activeSelf || _pc.activeSelf)
        {
            if (_mc.activeSelf)
            {
                if (_mc.GetComponent<MindControl>().IsCurrentControl)
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
        }

        if (InputSystemManager.Instance._isJump && IsGrounded())
        {
            if (_sj.activeSelf)
            {
                SuperJump.Instance.SuperJumpMethod();
                StartCoroutine(Vibration(1, 1, _shakeTime));
                return;
            }

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
        if (!jumpray) InputSystemManager.Instance._isJump = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            InputSystemManager.Instance._isSkill = false;
        }
    }
}

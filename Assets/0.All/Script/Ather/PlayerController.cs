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
    GameObject _lt;
    Animator _anim;

    bool _isDeadAnim;
    bool _isMoveAnim;
    bool _isJumpAnim;

    public bool On { set { _on = value; } }
    public float JumpSpeed { get { return _jumpSpeed; } }

    void Start()
    {
        _pc = SkillManager.Instance.transform.Find("1.Psychokinesis").gameObject;
        _mc = SkillManager.Instance.transform.Find("2.MindContorol").gameObject;
        _sj = SkillManager.Instance.transform.Find("3.SuperJump").gameObject;
        _lt = SkillManager.Instance.transform.Find("6.Light").gameObject;
        _bl = SkillManager.Instance.transform.Find("8.Blink").gameObject;
        _gh = SkillManager.Instance.transform.Find("7.GrapringHook" ).gameObject;
        StartSetUp();
        SetAnim();
    }

    void Update()
    {
        PlayerJump();
        Visible();
        Anim();
        PlayerVec();
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

    void PlayerVec()
    {
        if (_mc.activeSelf || _pc.activeSelf || _lt.activeSelf)
        {
            if (_mc.activeSelf)
            {
                if (_mc.GetComponent<MindControl>().IsCurrentControl)
                {
                    return;
                }
            }

            if (_pc.activeSelf)
            {
                if (_pc.GetComponent<Psychokinesis>().IsNowControl)
                {
                    return;
                }
            }

            if (_lt.activeSelf)
            {
                if (_lt.GetComponent<LightSkill>().IsNowControl)
                {
                    return;
                }
            }
        }

        if (InputSystemManager.Instance._vec1.x > 0)
        {
            transform.localScale = new Vector3(-0.15f, transform.localScale.y, transform.localScale.z);
        }
        else if(InputSystemManager.Instance._vec1.x < 0)
        {
            transform.localScale = new Vector3(0.15f, transform.localScale.y, transform.localScale.z);
        }
    }

    void Anim()
    {
        if (_mc.activeSelf || _pc.activeSelf || _lt.activeSelf)
        {
            if (_mc.activeSelf)
            {
                if (_mc.GetComponent<MindControl>().IsCurrentControl)
                {
                    return;
                }
            }

            if (_pc.activeSelf)
            {
                if (_pc.GetComponent<Psychokinesis>().IsNowControl)
                {
                    return;
                }
            }

            if (_lt.activeSelf)
            {
                if (_lt.GetComponent<LightSkill>().IsNowControl)
                {
                    return;
                }
            }
        }

        //_anim.SetBool("Dead", _isDeadAnim);
        _anim.SetBool("IsGrounded", IsGrounded());
        _anim.SetBool("IsJump", _isJumpAnim);
        _anim.SetBool("Move", _isMoveAnim);
        _isJumpAnim = false;
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
        if (_mc.activeSelf || _pc.activeSelf || _lt.activeSelf)
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

            if (_lt.activeSelf)
            {
                if (_lt.GetComponent<LightSkill>().IsNowControl)
                {
                    _rb.velocity = Vector2.zero;
                    return;
                }
            }
        }
        if (_bl.activeSelf && InputSystemManager.Instance._isSkill) return;
        if (_gh.activeSelf && InputSystemManager.Instance._isSkill) return;

        _rb.velocity = new Vector2(InputSystemManager.Instance._vec1.x * _moveSpeed, _rb.velocity.y);
        if(InputSystemManager.Instance._vec1.x == 0)
        {
            _isMoveAnim = false;
        }
        else
        {
            _isMoveAnim = true;
        }
    }

    /// <summary>
    /// プレイヤーのジャンプ処理 改善予定
    /// </summary>
    void PlayerJump()
    {
        if (InputSystemManager.Instance._cantPlayerInput)
            return;
        if (_mc.activeSelf || _pc.activeSelf || _lt.activeSelf)
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

            if (_lt.activeSelf)
            {
                if (_lt.GetComponent<LightSkill>().IsNowControl)
                {
                    _rb.velocity = Vector2.zero;
                    return;
                }
            }
        }

        
        if (InputSystemManager.Instance._isJump && IsGrounded() && !InputSystemManager.Instance._cantPlayerInput)
        {
            _isJumpAnim = true;
            AudioManager.Instance.SEPlay("SE", "jump", this.gameObject, false, 0.3f);
            if (_sj.activeSelf)
            {
                SuperJump.Instance.SuperJumpMethod();
                StartCoroutine(Vibration(1, 1, _shakeTime));
                return;
            }
            JumpMethod();
        }
    }

    public void SetAnim()
    {
        if (SkillManager.Instance.NowSetSkills[SkillManager.Instance.NowSkillNum])
        {
            GameObject obj = transform.Find(SkillManager.Instance.NowSetSkills[SkillManager.Instance.NowSkillNum].name).gameObject;
            _anim = obj.GetComponent<Animator>();
        }
        else
        {
            GameObject obj = transform.Find("0.Normal").gameObject;
            _anim = obj.GetComponent<Animator>();
        }
    }

    public void JumpMethod()
    {
        _rb.gravityScale = 3;
        _rb.velocity = Vector2.up * _jumpSpeed;
        InputSystemManager.Instance._isJump = false;
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

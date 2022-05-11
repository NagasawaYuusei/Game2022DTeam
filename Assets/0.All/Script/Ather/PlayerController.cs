using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    protected override bool dontDestroyOnLoad { get { return false; } }
    [Tooltip("�v���C���[��Rb")] Rigidbody2D _rb;
    [Header("�ݒ荀��")]
    [Tooltip("�ړ����x"), SerializeField] float _moveSpeed;
    [Tooltip("�W�����v�X�s�[�h"), SerializeField] float _jumpSpeed;
    [Tooltip("�W�����v���̃R���g���[���[�U��"), SerializeField] float _shakeTime;
    [Tooltip("�ݒu���苗��"), SerializeField] float _groundLength;
    [Tooltip("�n�ʂ̃��C���["), SerializeField] LayerMask _layerMask;
    [Tooltip("�ݒu������I���ɂ��邩�ǂ���"), SerializeField] bool _isGroundedVisible;

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
    /// Start�ł̃Z�b�g�A�b�v
    /// </summary>
    void StartSetUp()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// �ݒu����̉���
    /// </summary>
    void Visible()
    {
        if (_isGroundedVisible)
        {
            IsGrounded();
        }
    }

    /// <summary>
    /// �v���C���[�̈ړ�����
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
    /// �v���C���[�̃W�����v���� ���P�\��
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
    /// �ݒu����
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
    /// �R���g���[���[�U��
    /// </summary>
    /// <param name="lowFrequency"></param>
    /// <param name="highFrequency"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    private static IEnumerator Vibration
    (
        float lowFrequency, // ����g�i���j���[�^�[�̋����i0.0 �` 1.0�j
        float highFrequency, // �����g�i�E�j���[�^�[�̋����i0.0 �` 1.0�j
        float time
    )
    {
        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
            yield return new WaitForSeconds(time); // 1 �b�ԐU��������
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

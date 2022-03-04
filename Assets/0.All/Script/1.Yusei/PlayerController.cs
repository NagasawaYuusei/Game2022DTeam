using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Tooltip("�v���C���[��Rb")] Rigidbody2D _rb;
    [Header("�ݒ荀��")]
    [Tooltip("�ړ����x"), SerializeField] float _moveSpeed;
    [Tooltip("�W�����v�X�s�[�h"), SerializeField] float _jumpSpeed;
    [Tooltip("�W�����v���̃R���g���[���[�U��"), SerializeField] float _shakeTime;
    [Tooltip("�ݒu���苗��"), SerializeField] float _groundLength;
    [Tooltip("�n�ʂ̃��C���["), SerializeField] LayerMask _layerMask;
    [Tooltip("�ݒu������I���ɂ��邩�ǂ���"), SerializeField] bool _isGroundedVisible;
    SuperJump _sj;

    void Start()
    {
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
        _rb.velocity = new Vector2(InputSystemManager.Instance._vec1.x * _moveSpeed, _rb.velocity.y);
    }

    /// <summary>
    /// �v���C���[�̃W�����v���� ���P�\��
    /// </summary>
    public void PlayerJump()
    {
        if(TryGetComponent<SuperJump>(out _sj))
        {
            return;
        }
        if (InputSystemManager.Instance._isJump && IsGrounded())
        {
            _rb.velocity = Vector2.up * _jumpSpeed;
            StartCoroutine(Vibration(1, 1, _shakeTime));
        }
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
        if(jumpray && !_sj)
        {
            _sj.JumpCount = 0;
        }
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
}

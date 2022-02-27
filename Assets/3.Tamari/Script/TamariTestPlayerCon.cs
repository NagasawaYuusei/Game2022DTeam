using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C���[�R���g���[���[�e�X�g
/// </summary>
public class TamariTestPlayerCon : MonoBehaviour
{
    [Tooltip("�v���C���[��Rb")]Rigidbody2D _rb;
    [Tooltip("InputSystem�̈ړ�����")]Vector2 _playerVec;
    [Header("�ݒ荀��")]
    [Tooltip("�ړ����x"), SerializeField] float _moveSpeed;
    [Tooltip("�W�����v�X�s�[�h"), SerializeField] float _jumpSpeed;
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
    /// Start�ł̃Z�b�g�A�b�v
    /// </summary>
    void StartSetUp()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// �v���C���[�̈ړ�����
    /// </summary>
    void PlayerMove()
    {
        _rb.velocity = new Vector2(_moveSpeed * _playerVec.x, _rb.velocity.y);
    }

    /// <summary>
    /// �v���C���[�̃W�����v����
    /// </summary>
    public void PlayerJump()
    {
        _rb.velocity = Vector2.up * _jumpSpeed;
    }

    /// <summary>
    /// InputSystem
    /// �ړ�
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
    /// �W�����v
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
        float lowFrequency, // ����g�i���j���[�^�[�̋����i0.0 �` 1.0�j
        float highFrequency, // �����g�i�E�j���[�^�[�̋����i0.0 �` 1.0�j
        float time
    )
    {
        var gamepad = Gamepad.current;
        gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
        yield return new WaitForSeconds(time); // 1 �b�ԐU��������
        gamepad.SetMotorSpeeds(0, 0);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C���[�R���g���[���[�e�X�g
/// </summary>
public class TestPlayerCon : MonoBehaviour
{
    [Tooltip("�v���C���[��Rb")]Rigidbody2D _rb;
    [Tooltip("InputSystem�̈ړ�����")]Vector2 _playerVec;
    [Header("�ݒ荀��")]
    [Tooltip("�ړ����x"), SerializeField] float _moveSpeed;
    [Tooltip("�W�����v�X�s�[�h"), SerializeField] float _jumpSpeed;
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
        _rb.velocity = new Vector2(_moveSpeed * InputSystemManager.Instance._vec1.x, _rb.velocity.y);
    }

    /// <summary>
    /// �v���C���[�̃W�����v����
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

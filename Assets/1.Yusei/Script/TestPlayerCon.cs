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
    void PlayerJump()
    {
        _rb.AddForce(Vector2.up, ForceMode2D.Impulse);
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
        }
    }
}

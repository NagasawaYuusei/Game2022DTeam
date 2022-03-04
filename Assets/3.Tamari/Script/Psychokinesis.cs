using UnityEngine;
using UnityEngine.InputSystem;

public class Psychokinesis : MonoBehaviour
{
    [SerializeField] GameObject _block = default;
    [Tooltip("�u���b�N��Rb")] Rigidbody2D _blockRb;
    [Tooltip("InputSystem�̈ړ�����")] Vector2 _blockVec;
    [Header("�ݒ荀��")]
    [Tooltip("�ړ����x"), SerializeField] float _blockMoveSpeed;

    [Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isPsychokinesis = false;

    public bool IsPsychokinesis { get { return _isPsychokinesis; } set { _isPsychokinesis = value; } }

    private void Update()
    {
        PsychokinesisMove();
    }
    /// <summary>
    /// �X�L���������̓u���b�N�𓮂�����
    /// </summary>
    void PsychokinesisMove()
    {
        if (_isPsychokinesis)
        {
            _blockRb = GetComponent<Rigidbody2D>();
            _blockRb.velocity = new Vector2(_blockMoveSpeed * _blockVec.x, _blockMoveSpeed * _blockRb.velocity.y);
        }
    }

    /// <summary>
    /// InputSystem
    /// �u���b�N�̈ړ�
    /// </summary>
    /// <param name="context"></param>
    public void BlockMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _blockVec = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _blockVec = Vector2.zero;
        }
    }
}

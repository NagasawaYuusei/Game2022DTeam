using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemManager : SingletonMonoBehaviour<InputSystemManager>
{
    protected override bool dontDestroyOnLoad { get { return false; } }
    [Tooltip("Default ���X�e�B�b�N")] public Vector2 _vec1;
    [Tooltip("Default �E�X�e�B�b�N")] public Vector2 _vec2;
    [Tooltip("Default �\���L�[")] public Vector2 _vec3;
    [Tooltip("Jump�L�[")] public bool _isJump;
    [Tooltip("�X�L���L�[")] public bool _isSkill;

    public void PlayerMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _vec1 = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _vec1 = Vector2.zero;
        }
    }

    public void PlayerStickInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _vec2 = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _vec2 = Vector2.zero;
        }
    }

    public void PlayerJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isJump = true;
        }
    }

    public void PlayerSkillInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isSkill = true;
        }
    }
}

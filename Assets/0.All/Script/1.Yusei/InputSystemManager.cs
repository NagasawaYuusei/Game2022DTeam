using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemManager : SingletonMonoBehaviour<InputSystemManager>
{
    protected override bool dontDestroyOnLoad { get { return false; } }
    [Tooltip("Default 左スティック")] public Vector2 _vec1;
    [Tooltip("Default 右スティック")] public Vector2 _vec2;
    [Tooltip("Default 十字キー")] public Vector2 _vec3;
    [Tooltip("Jumpキー")] public bool _isJump;
    [Tooltip("スキルキー")] public bool _isSkill;

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

using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemManager : SingletonMonoBehaviour<InputSystemManager>
{
    protected override bool dontDestroyOnLoad { get { return false; } }
    [Tooltip("Default 左スティック")] public Vector2 _vec1 { get; set; }
    [Tooltip("Default 右スティック")] public Vector2 _vec2 { get; set; }
    [Tooltip("Default 十字キー")] public Vector2 _vec3 { get; set; }
    [Tooltip("Jumpキー")] public bool _isJump { get; set; }
    [Tooltip("スキルキー")] public bool _isSkill { get; set; }

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

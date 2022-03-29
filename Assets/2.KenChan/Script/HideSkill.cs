using UnityEngine;
using UnityEngine.InputSystem;

public class HideSkill : MonoBehaviour
{
    [Tooltip("Medusaを発動したかどうか")] public bool _hideCheck = false;
    [SerializeField, Tooltip("このスキルが使えるかどうか")] bool _isHide = true;
    public bool IsHide { get { return _isHide; } set { _isHide = value; } }
    

    /// <summary>
    /// InputSystem
    /// 隠れる
    /// </summary>
    /// <param name="context"></param>
    public void PlayerMedusaInput(InputAction.CallbackContext context)
    {
        if (_isHide)
        {
            if (context.started)
            {
                _hideCheck = true;
            }
        }
    }
}

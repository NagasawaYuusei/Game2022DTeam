using UnityEngine;
using UnityEngine.InputSystem;

public class HideSkill : MonoBehaviour
{
    [Tooltip("Medusa‚ð”­“®‚µ‚½‚©‚Ç‚¤‚©")] public bool _hideCheck = false;
    [SerializeField, Tooltip("‚±‚ÌƒXƒLƒ‹‚ªŽg‚¦‚é‚©‚Ç‚¤‚©")] bool _isHide = true;
    public bool IsHide { get { return _isHide; } set { _isHide = value; } }
    

    /// <summary>
    /// InputSystem
    /// ‰B‚ê‚é
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

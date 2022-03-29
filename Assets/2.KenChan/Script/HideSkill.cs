using UnityEngine;
using UnityEngine.InputSystem;

public class HideSkill : MonoBehaviour
{
    [Tooltip("Medusa�𔭓��������ǂ���")] public bool _hideCheck = false;
    [SerializeField, Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isHide = true;
    public bool IsHide { get { return _isHide; } set { _isHide = value; } }
    

    /// <summary>
    /// InputSystem
    /// �B���
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

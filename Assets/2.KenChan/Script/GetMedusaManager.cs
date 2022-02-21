using UnityEngine;
using UnityEngine.InputSystem;

public class GetMedusaManager : MonoBehaviour
{
    [Tooltip("Medusaを発動したかどうか")] public bool _medusaCheck = false;
    [SerializeField, Tooltip("このスキルが使えるかどうか")] bool _isMedusa = true;
    public bool IsMedusa { get { return _isMedusa; } set { _isMedusa = value; } }
    // Start is called before the first frame update

    /// <summary>
    /// InputSystem
    /// 敵を止める
    /// </summary>
    /// <param name="context"></param>
    public void PlayerMedusaInput(InputAction.CallbackContext context)
    {
        if (_isMedusa)
        {
            if (context.started)
            {
                _medusaCheck = true;
            }
        }
    }
}

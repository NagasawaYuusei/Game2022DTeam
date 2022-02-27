using UnityEngine;
using UnityEngine.InputSystem;

public class GetMedusaManager : MonoBehaviour
{
    [Tooltip("Medusa‚ð”­“®‚µ‚½‚©‚Ç‚¤‚©")] public bool _medusaCheck = false;
    [SerializeField, Tooltip("‚±‚ÌƒXƒLƒ‹‚ªŽg‚¦‚é‚©‚Ç‚¤‚©")] bool _isMedusa = true;
    public bool IsMedusa { get { return _isMedusa; } set { _isMedusa = value; } }
    // Start is called before the first frame update

    /// <summary>
    /// InputSystem
    /// “G‚ðŽ~‚ß‚é
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

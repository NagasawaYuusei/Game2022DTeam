using UnityEngine;
using UnityEngine.InputSystem;

public class GetMedusaManager : MonoBehaviour
{
    [Tooltip("Medusa�𔭓��������ǂ���")] public bool _medusaCheck = false;
    [SerializeField, Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isMedusa = true;
    public bool IsMedusa { get { return _isMedusa; } set { _isMedusa = value; } }
    // Start is called before the first frame update

    /// <summary>
    /// InputSystem
    /// �G���~�߂�
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

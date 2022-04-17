using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �R���g���[���[�U���e�X�g�R���|�[�l���g
/// </summary>
public class ShakeTest : MonoBehaviour
{
    [SerializeField] float _first;
    [SerializeField] float _second;


    //private IEnumerator Start()
    //{
    //    Gamepad gamepad = Gamepad.current;
    //    if (gamepad != null)
    //    {
    //        gamepad.SetMotorSpeeds(1.0f, 1.0f);
    //        yield return new WaitForSeconds(3.0f);
    //        gamepad.SetMotorSpeeds(0.0f, 0.0f);
    //    }
    //}

    /// <summary>
    /// �ŏ�����U��������
    /// </summary>
    private void Start()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(_first, _second);
        }
    }
}

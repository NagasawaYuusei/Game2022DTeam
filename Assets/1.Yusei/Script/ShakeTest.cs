using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Start()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(_first, _second);
        }
    }
}

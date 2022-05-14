using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleManager : MonoBehaviour
{
    private InputAction _pressAnyKeyAction =
            new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press");

    private void OnEnable() => _pressAnyKeyAction.Enable();
    private void OnDisable() => _pressAnyKeyAction.Disable();

    void Update()
    {
        if (_pressAnyKeyAction.triggered)
        {
            //シーン読み込み、アニメーション読み込みなどなど
        }
    }
}


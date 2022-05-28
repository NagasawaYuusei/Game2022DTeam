using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{

    private InputAction _pressAnyKeyAction =
           new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press");

    private void OnEnable() => _pressAnyKeyAction.Enable();
    private void OnDisable() => _pressAnyKeyAction.Disable();

    string _titleName;

    void Update()
    {
        if (_pressAnyKeyAction.triggered && GameManager.Instance.IsDead)
        {
            GameManager.Instance.ChangeRestart();
            _titleName = SceneManager.GetActiveScene().name;
            SceneController.Instance.ChangeScene(_titleName);
        }
    }
}

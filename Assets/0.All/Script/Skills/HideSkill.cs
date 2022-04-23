using UnityEngine;
using UnityEngine.InputSystem;

public class HideSkill : MonoBehaviour
{
    void Update()
    {
        HideReady();
    }

    void HideReady()
    {
        if(InputSystemManager.Instance._isSkill)
        {
            GameManager.Instance.ChangePlayerHide();
            InputSystemManager.Instance._isSkill = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControlle : MonoBehaviour
{
    void Update()
    {
        if(Floor3_2SwitchController.Instance._isFloorOpened == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}

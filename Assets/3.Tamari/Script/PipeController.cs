using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    void Update()
    {
        if(Floor3_11SwitchController.Instance._isPipeOpened == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}

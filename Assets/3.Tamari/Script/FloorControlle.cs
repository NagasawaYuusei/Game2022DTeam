using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControlle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SwitchController.Instance._isOpened == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLightScript : MonoBehaviour
{
    [SerializeField] Light _light;
    void Start()
    {
        _light = GetComponent<Light>();
        _light.intensity = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightCon : MonoBehaviour
{
    [SerializeField] double _insen;
    Light2D _light;

    void Start()
    {
        _light = GetComponent<Light2D>();
    }
    void FixedUpdate()
    {
        _light.intensity += 0.1f;
        if( _light.intensity > _insen)
        {
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    [Header("スイッチ本体")]
    [SerializeField, Tooltip("ボタン本体")] GameObject _swichBase;

    [Header("スイッチボタン")]
    [SerializeField, Tooltip("ボタン押すところ")] GameObject _button;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

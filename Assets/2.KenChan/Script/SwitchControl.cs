using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    [Header("スイッチ本体")]
    [SerializeField, Tooltip("ボタン本体")] GameObject _swichBase;

    [Header("スイッチボタン")]
    [SerializeField, Tooltip("ボタン押すところ")] GameObject _button;

    [Tooltip("アニメーション")] Animation _anim;
    void Start()
    {
        _anim = _swichBase.GetComponent<Animation>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("当たった");
            _anim.Play("DownSwich");
    }
}

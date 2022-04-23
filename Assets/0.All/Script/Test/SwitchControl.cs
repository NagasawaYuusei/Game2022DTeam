using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    [Header("�{�^���{��")]
    [SerializeField, Tooltip("�{�^���{��")] GameObject _swichBase;

    Animator _anim;
    void Start()
    {
        _anim = _swichBase.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("��������");

            _anim.SetBool("ON",true);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���ꂽ");

            _anim.SetBool("ON", false);
        }
    }
}

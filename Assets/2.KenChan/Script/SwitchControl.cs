using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    [Header("�X�C�b�`�{��")]
    [SerializeField, Tooltip("�{�^���{��")] GameObject _swichBase;

    [Tooltip("�A�j���[�V����")] Animation _anim;
    void Start()
    {
        _anim = _swichBase.GetComponent<Animation>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("��������");
            //_anim.Play("DownSwich");
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    [Header("�X�C�b�`�{��")]
    [SerializeField, Tooltip("�{�^���{��")] GameObject _swichBase;

    [Header("�X�C�b�`�{�^��")]
    [SerializeField, Tooltip("�{�^�������Ƃ���")] GameObject _button;

    [Tooltip("�A�j���[�V����")] Animation _anim;
    void Start()
    {
        _anim = _swichBase.GetComponent<Animation>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("��������");
            _anim.Play("DownSwich");
    }
}

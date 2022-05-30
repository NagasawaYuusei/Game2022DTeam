using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObj : MonoBehaviour
{
    [Tooltip("�I�u�W�F�N�g�̃A�j���[�V����")] Animator _anim;
    [Tooltip("�I�u�W�F�N�g�̃T�E���h")] AudioSource _audio;

    private void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
        _audio = this.gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// �v���C���[������������A�j���[�V�������Đ�
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("Fall", true);
        }
    }

    void PlaySound()
    {
        AudioManager.Instance.SEPlay("SE", "drop_paint", this.gameObject, false);
    }
}

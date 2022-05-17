using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPicture : MonoBehaviour
{
    [Tooltip("オブジェクトのアニメーション")] Animator _anim;
    [Tooltip("オブジェクトのサウンド")] AudioSource _audio;

    private void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
        _audio = this.gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// プレイヤーが当たったらアニメーションが再生
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
        _audio.Play();
    }
}

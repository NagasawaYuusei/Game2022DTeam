using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ImageAlpha : MonoBehaviour
{
    [Tooltip("���߂���G")] SpriteRenderer _fadeImage;

    private void Start()
    {
        _fadeImage = this.gameObject.GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// �v���C���[�����������G�𔖂�����
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DOTween.ToAlpha(
                () => _fadeImage.color,
                c => _fadeImage.color = c,
                0f,
                0.5f
                );
            Debug.Log("������");
        }
    }

    /// <summary>
    /// �v���C���[���o�����G��߂�
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DOTween.ToAlpha(
                () => _fadeImage.color,
                alpha => _fadeImage.color = alpha,
                1f,
                0.5f
                );
            Debug.Log("������");
        }
    }

}

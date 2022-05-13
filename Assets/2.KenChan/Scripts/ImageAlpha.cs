using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ImageAlpha : MonoBehaviour
{
    [Tooltip("透過する絵")] SpriteRenderer _fadeImage;

    private void Start()
    {
        _fadeImage = this.gameObject.GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// プレイヤーが入った時絵を薄くする
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
            Debug.Log("あああ");
        }
    }

    /// <summary>
    /// プレイヤーが出た時絵を戻す
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
            Debug.Log("いいい");
        }
    }

}

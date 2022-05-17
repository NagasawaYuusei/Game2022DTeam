using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OderInRayerChenge : MonoBehaviour
{
    [Tooltip("SpriteRenderer")] SpriteRenderer _renderer;
    [Tooltip("OrderInRayer�l�ۊ�")] int _saveOrderInRayer;
    [Header("OrderInRayer�ύX�l")]
    [SerializeField,Tooltip("OrderInRayer�ύX�l")] int _changeOrderInRayer;
    void Start()
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
        _saveOrderInRayer = _renderer.sortingOrder;
    }

    /// <summary>
    /// �v���C���[����������OrderInRayer��O�ɂ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _renderer.sortingOrder = _changeOrderInRayer;
        }
    }

    /// <summary>
    /// �v���C���[���o����OrderInRayer��߂�
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _renderer.sortingOrder = _saveOrderInRayer;
        }
    }
}

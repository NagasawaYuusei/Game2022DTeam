using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OderInRayerChenge : MonoBehaviour
{
    [Tooltip("SpriteRenderer")] SpriteRenderer _renderer;
    [Tooltip("OrderInRayer値保管")] int _saveOrderInRayer;
    [Header("OrderInRayer変更値")]
    [SerializeField,Tooltip("OrderInRayer変更値")] int _changeOrderInRayer;
    void Start()
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
        _saveOrderInRayer = _renderer.sortingOrder;
    }

    /// <summary>
    /// プレイヤーが入ったらOrderInRayerを前にする
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
    /// プレイヤーが出たらOrderInRayerを戻す
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

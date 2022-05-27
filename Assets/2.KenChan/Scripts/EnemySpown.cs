using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    [Header("スポーン")]
    [SerializeField, Tooltip("スポーンする敵")] GameObject _enemy;
    [Tooltip("スポーンする場所")] Transform _pos;
    [Tooltip("発動したかの判定")] bool _check;
    private void Start()
    {
        _pos = this.gameObject.GetComponent<Transform>();
    }

    /// <summary>
    /// プレイヤーが範囲内に入ったら
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !_check)
        {
            Instantiate(_enemy, _pos.position, Quaternion.identity);
            _check = true;
        }
    }
}

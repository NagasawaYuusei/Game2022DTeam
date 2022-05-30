using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Floor3_7SpawnController : MonoBehaviour
{
    [Header("生成される敵"), Tooltip("生成される敵"), SerializeField] GameObject _enemy;
    [Header("生成開始のフラグ"), Tooltip("生成開始のフラグ")] bool _isSpawned;
    [SerializeField,Tooltip("エネミーの出現する場所")] Transform[] _spawnPos = new Transform[4];
    [SerializeField, Tooltip("ライトの色")] Light2D _light;

    void AppearEnemys()
    {
        if (_isSpawned) return;
        foreach(var pos in _spawnPos)
        {
            GameObject.Instantiate(_enemy, pos.position, Quaternion.identity);
            _isSpawned = true;
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.SEPlay("SE", "siren", this.gameObject, false);
            AppearEnemys();
            _light.color = Color.red;
        }
    }
}

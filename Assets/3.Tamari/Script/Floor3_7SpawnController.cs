using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Floor3_7SpawnController : MonoBehaviour
{
    [Header("生成される敵"), Tooltip("生成される敵"), SerializeField] GameObject _enemy;
    [Header("生成開始のフラグ"), Tooltip("生成開始のフラグ")] bool _isSpawned;
    [SerializeField,Tooltip("エネミーの出現する場所")] Transform[] _spawnPos = new Transform[4];

    Light2D _light = default;

    // Start is called before the first frame update
    
    void AppearEnemys()
    {
        if (_isSpawned) return;
        foreach(var pos in _spawnPos)
        {
            GameObject.Instantiate(_enemy, pos.position, Quaternion.identity);
            _isSpawned = true;
        }   
    }
    //void ChangeLight2D()
    //{
    //    if (_isSpawned) return;
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AppearEnemys();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor3_7SpawnController : MonoBehaviour
{
    [Header("生成される敵"), Tooltip("生成される敵"), SerializeField] GameObject _enemy;
    [Header("生成開始のフラグ"), Tooltip("生成開始のフラグ")] bool _isSpawned;

    // Start is called before the first frame update
    void Start()
    {
        AppearEnemys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AppearEnemys()
    {
        GameObject.Instantiate(_enemy, transform.position, Quaternion.identity);
    }
}

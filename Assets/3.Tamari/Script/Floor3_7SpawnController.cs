using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor3_7SpawnController : MonoBehaviour
{
    [Header("���������G"), Tooltip("���������G"), SerializeField] GameObject _enemy;
    [Header("�����J�n�̃t���O"), Tooltip("�����J�n�̃t���O")] bool _isSpawned;

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

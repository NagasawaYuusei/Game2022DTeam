using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Floor3_7SpawnController : MonoBehaviour
{
    [Header("���������G"), Tooltip("���������G"), SerializeField] GameObject _enemy;
    [Header("�����J�n�̃t���O"), Tooltip("�����J�n�̃t���O")] bool _isSpawned;
    [SerializeField,Tooltip("�G�l�~�[�̏o������ꏊ")] Transform[] _spawnPos = new Transform[4];
    [SerializeField, Tooltip("���C�g�̐F")] Light2D _light;

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

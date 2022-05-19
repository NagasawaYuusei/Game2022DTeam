using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    [Header("�X�|�[��")]
    [SerializeField, Tooltip("�X�|�[������G")] GameObject _enemy;
    [Tooltip("�X�|�[������ꏊ")] Transform _pos;

    private void Start()
    {
        _pos = this.gameObject.GetComponent<Transform>();
    }

    /// <summary>
    /// �v���C���[���͈͓��ɓ�������
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_enemy, _pos.position, Quaternion.identity);
        }
    }
}

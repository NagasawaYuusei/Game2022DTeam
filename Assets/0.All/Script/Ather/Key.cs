using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] int _keyNum;

    private void Start()
    {
        if(GameManager.Instance.IsKey[_keyNum])
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.IsKeyChange(_keyNum);
            Destroy(gameObject);
        }
    }
}

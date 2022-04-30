using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBox : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] string _waterTag;
    [SerializeField] string _groundTag;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (_rb.velocity.y < _speed)
        //{
            if (collision.tag == _waterTag)
            {
                Debug.Log("‚¿‚á‚Û‚ñ");
            }
            else if (collision.tag == _groundTag)
            {
                Debug.Log("‚Ç‚·‚ñ");
            }
        //}
    }
}

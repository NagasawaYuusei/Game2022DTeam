using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeathEnemy : MonoBehaviour
{
    [SerializeField] GameObject _particle;
    bool _playerDead;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !_playerDead)
        {
            GameManager.Instance.PlayerDeath();
            _playerDead = true;
        }

        if(collision.gameObject.tag == "PsychokinesisObject")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb.velocity.y > 1)
            {
                Instantiate(_particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}

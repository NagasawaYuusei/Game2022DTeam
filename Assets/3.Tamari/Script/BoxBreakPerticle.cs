using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;
    [SerializeField] Renderer _rend;
    [Tooltip("オブジェクトが消えるまでの時間"), SerializeField] float _destroyTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _particle.Play();
            _rend.enabled = false;
            Destroy(gameObject,_destroyTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] GameObject _particle;
    //[SerializeField] Renderer _sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(_particle,this.transform.position,Quaternion.identity);
            //_sprite.GetComponent<Renderer>().enabled = false;
            //Destroy(gameObject);
        }
    }
}

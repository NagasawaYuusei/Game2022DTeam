using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor3_4Pipe : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDeath();
            AudioManager.Instance.SEPlay("SE","iron_pipe",this.gameObject,false);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            AudioManager.Instance.SEPlay("SE", "iron_pipe", this.gameObject, false);
        }
        
    }

   

}

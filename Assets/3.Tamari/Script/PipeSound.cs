using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            AudioManager.Instance.SEPlay("SE", "iron_pipe", this.gameObject, false);
        }
    }
}

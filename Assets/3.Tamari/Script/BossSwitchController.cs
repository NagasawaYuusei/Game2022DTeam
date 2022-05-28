using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitchController : MonoBehaviour
{
    Animator _switchAnim;
    void Start()
    {
        _switchAnim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PsychokinesisObject")
        {
            _switchAnim.SetBool("Switch", true);
        }
    }
}

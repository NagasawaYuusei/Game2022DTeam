using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitchController : MonoBehaviour
{
    Animator _switchAnim;
    bool _isSounded;
    void Start()
    {
        _switchAnim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PsychokinesisObject")
        {
            _switchAnim.SetBool("Switch", true);
            if (!_isSounded)
            {
                AudioManager.Instance.SEPlay("SE", "lever", this.gameObject, false, 2.0f);
                _isSounded = true;
            }
        }
    }
}

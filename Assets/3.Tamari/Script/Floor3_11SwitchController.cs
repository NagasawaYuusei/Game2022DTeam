using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor3_11SwitchController : MonoBehaviour
{
    public static Floor3_11SwitchController Instance { get; private set; }
    [Header("è∞Ç™Ç†Ç¢ÇΩÇ©Ç«Ç§Ç©"), Tooltip("è∞Ç™Ç†Ç¢ÇΩÇ©Ç«Ç§Ç©")] public bool _isPipeOpened;
    Animator _switchAnim;
    bool _isSounded;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        _switchAnim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PsychokinesisObject")
        {
            _isPipeOpened = true;
            _switchAnim.SetBool("Switch", true);
            if (!_isSounded)
            {
                AudioManager.Instance.SEPlay("SE", "lever", this.gameObject, false, 2.0f);
                _isSounded = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public static SwitchController Instance { get; private set; }
    [Header("床があいたかどうか"), Tooltip("床があいたかどうか")] public bool _isOpened;
    Animator _switchAnim;
    // Start is called before the first frame update

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }  
    }

    private void Start()
    {
        _switchAnim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PsychokinesisObject")
        {
            Debug.Log("スイッチON");
            _isOpened = true;
            _switchAnim.SetBool("Switch", true);
        }
    }
}

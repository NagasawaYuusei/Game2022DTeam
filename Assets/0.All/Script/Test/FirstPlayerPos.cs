using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerPos : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Awake()
    {
        if (!GameManager.Instance.First)
        {
            GameManager.Instance.PosNum = 1;
            GameManager.Instance.First = true;
        }
        _player.transform.position = GameObject.Find("FirstPlayerPos" + GameManager.Instance.PosNum.ToString()).transform.position;
    }
}

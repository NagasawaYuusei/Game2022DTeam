using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerPos : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.Find("FirstPlayerPos" + GameManager.Instance.PosNum.ToString()).transform.position;
    }
}

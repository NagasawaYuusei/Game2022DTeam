using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerPos : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Awake()
    {
        _player.transform.position = GameObject.Find("FirstPlayerPos" + GameManager.Instance._num.ToString()).transform.position;
    }
}

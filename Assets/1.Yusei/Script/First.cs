using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    void Awake()
    {
        if(!GameManager.Instance._first)
        {
            GameManager.Instance._num = 1;
            GameManager.Instance._first = true;
        }
    }
}

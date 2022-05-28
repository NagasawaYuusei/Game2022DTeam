using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKey : MonoBehaviour
{
    [SerializeField] int _keyNum;
    [SerializeField] SceneMoveCollider _collider;
    [SerializeField] SceneMove _sm;
    void Start()
    {
        if(!GameManager.Instance.IsKey[_keyNum])
        {
            if(_collider)
            {
                _collider.enabled = false;
            }
            
            if(_sm)
            {
                _sm.enabled = false;
            }
        }
    }
}

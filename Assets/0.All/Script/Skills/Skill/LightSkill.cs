using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSkill : ObjectSelectContoroller
{
    [SerializeField] string _lightTagName;
    GameObject _lightObject;
    void Update()
    {
        LightReady();
    }

    void LightReady()
    {
        //�T�C�R�L�l�V�X�Q�l�ɂ��Ȃ�����
        if(InputSystemManager.Instance._isSkill)
        {
            Select(_lightTagName);
            _lightObject = First();
        }
    }
}

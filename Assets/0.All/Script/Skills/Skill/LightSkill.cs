using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSkill : ObjectSelectContoroller
{
    [SerializeField] string _lightTagName;
    GameObject _lightObject;
    bool _isNowControl;
    Color _originColor;
    bool on;

    public bool IsNowControl => _isNowControl;
    void Update()
    {
        LightReady();
    }

    void LightReady()
    {
        if (InputSystemManager.Instance._isSkill && !_isNowControl)
        {
            Select("LightObject");
            _lightObject = First();
            if (_lightObject)
            {
                _originColor = _lightObject.GetComponent<SpriteRenderer>().color;
                _lightObject.GetComponent<SpriteRenderer>().color = Color.yellow;

                _isNowControl = true;
            }
            InputSystemManager.Instance._isSkill = false;
            //AudioManager.Instance.SEPlay("SE", "nenriki", GameObject.FindGameObjectWithTag("Player"), true, 0.01f);
        }
        else if (InputSystemManager.Instance._isSkill && _isNowControl)
        {
            _lightObject.GetComponent<SpriteRenderer>().color = _originColor;
            _isNowControl = false;
            InputSystemManager.Instance._isSkill = false;
        }

        if (_isNowControl)
        {
            if (InputSystemManager.Instance._vec2.y > 0 && !on)
            {
                _lightObject.GetComponent<SpriteRenderer>().color = _originColor;
                _lightObject = Change(1);

                _originColor = _lightObject.GetComponent<SpriteRenderer>().color;
                _lightObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                on = true;
            }
            else if (InputSystemManager.Instance._vec2.y < 0 && !on)
            {
                _lightObject.GetComponent<SpriteRenderer>().color = _originColor;
                _lightObject = Change(-1);

                _originColor = _lightObject.GetComponent<SpriteRenderer>().color;
                _lightObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                on = true;
            }
            else if (InputSystemManager.Instance._vec2.y == 0 && on)
            {
                on = false;
            }

            if(InputSystemManager.Instance._isJump)
            {
                _lightObject.transform.Find("Light").gameObject.SetActive(true);
                InputSystemManager.Instance._isJump = false;
            }
        }
    }
}

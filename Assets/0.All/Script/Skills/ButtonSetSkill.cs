using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetSkill : MonoBehaviour
{
    Button _buttom;
    [SerializeField] int _skillNum;

    void Awake()
    {
        _buttom = GetComponent<Button>();
        if(_skillNum == 0)
        {
            _buttom.onClick.AddListener(() => A());
            return;
        }
        _buttom.onClick.AddListener(() => SkillManager.Instance.SetSkill(_skillNum));
    }

    private void A()
    {
        SkillManager.Instance.SetClear();
        GameObject.Find("SkillSet").SetActive(false);
    }
}

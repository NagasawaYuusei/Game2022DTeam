using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSetUseSkill : MonoBehaviour
{
    [SerializeField] Sprite _noneSprite;
    [SerializeField] Sprite _selectSprite;
    [SerializeField] Sprite _useSprite;
    [SerializeField] Image[] _skillImages;
    void Start()
    {
        UseingSkills();
    }

    public void UseingSkills()
    {
        for(int i = 0; i < 8; i++)
        {
            _skillImages[i].sprite = _noneSprite;
        }
        for(int i = 0; i < 3; i++)
        {
            if(SkillManager.Instance.NowSetSkills[i])
            {
                var str = SkillManager.Instance.NowSetSkills[i].name.Split('.');
                _skillImages[int.Parse(str[0]) - 1].sprite = _useSprite;
            }
        }
    }

    public void SelectSkill(int i, bool on)
    {
        if (!on)
            _skillImages[i].sprite = _selectSprite;
        else if (on)
             _skillImages[i].sprite = _noneSprite;
    }
}

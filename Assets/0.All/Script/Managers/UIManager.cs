using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text[] _texts;
    void Update()
    {
        _texts[0].text = SkillManager.Instance.NowSetSkills[0].name;
        _texts[1].text = SkillManager.Instance.NowSetSkills[1].name;
        _texts[2].text = SkillManager.Instance.NowSetSkills[2].name;
        _texts[3].text = "Now:" + SkillManager.Instance.NowSetSkills[SkillManager.Instance.NowSkillNum].name;
    }
}

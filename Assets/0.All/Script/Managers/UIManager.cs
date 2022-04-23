using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _text;
    void Update()
    {
        if (SkillManager.Instance.NowSetSkills[SkillManager.Instance.NowSkillNum])
            _text.text = SkillManager.Instance.NowSetSkills[SkillManager.Instance.NowSkillNum].name;
    }
}

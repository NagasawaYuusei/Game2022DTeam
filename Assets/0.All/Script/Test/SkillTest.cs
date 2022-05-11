using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTest : MonoBehaviour
{
    [Tooltip("セットされてるスキル"), SerializeField] int[] _nowSetSkills = new int[3];
    void Awake()
    {
        SkillManager.Instance.SetSkills(_nowSetSkills);
        SkillManager.Instance.FirstSetSkill();
    }
}

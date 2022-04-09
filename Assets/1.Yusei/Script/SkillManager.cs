using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : SingletonMonoBehaviour<SkillManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    int _nowSkillNum;
    int[] _nowSetSkills = new int[3];
    public int NowSkillNum { get { return _nowSkillNum; } set { _nowSkillNum = value; } }
    public int[] NowSetSkills { get { return _nowSetSkills; } set { _nowSetSkills = value; } }

    int _nowSkillOrder;

    public void SetSkill(int[] i)
    {
        if (i.Length != 3)
        {
            Debug.LogError("Skill‚Ì”‚Í‚R‚Â‚É‚µ‚Ä‚­‚¾‚³‚¢");
            return;
        }
        for(int j = 0; j < 3; j++)
        {
            _nowSetSkills[j] = i[j];
        }
    }

    public void SkillChange()
    {
        _nowSkillNum++;
        if(_nowSkillNum == 3)
        {
            _nowSkillNum = 0;
        }
        _nowSkillOrder = _nowSetSkills[_nowSkillNum];
    }
}

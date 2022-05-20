using System;
using UnityEngine;

public class First : MonoBehaviour
{
    void Start()
    {
        GameObject skill = GameObject.Find("SkillManager");
        if (skill)
            skill.GetComponent<SkillManager>().Start();
        skill = GameObject.Find("2.MindContorol");
        if (skill)
            skill.GetComponent<MindControl>().Start();
        skill = GameObject.Find("3.SuperJump");
        if (skill)
            skill.GetComponent<SuperJump>().Start();
        skill = GameObject.Find("7.GrapringHook");
        if (skill)
            skill.GetComponent<GrapllingContoroller>().Start();
        skill = GameObject.Find("8.Blink");
        if (skill)
            skill.GetComponent<BlinkSkill>().Ready();
    }
}

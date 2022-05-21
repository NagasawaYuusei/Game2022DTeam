using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class First : MonoBehaviour
{
    void Awake()
    {
        GameObject bgm = GameObject.Find("syouzyonoheya(CriAtomSource)");
        if(bgm)
        {
            bgm.GetComponent<BGMContoroller>().Awake();
        }
    }

    void Start()
    {
        GameObject skill = GameObject.Find("SkillManager");
        if (skill)
            skill.GetComponent<SkillManager>().Start();
        skill = GameObject.Find("SkillManager").transform.Find("2.MindContorol").gameObject;
        if (skill)
            skill.GetComponent<MindControl>().Start();
        skill = GameObject.Find("SkillManager").transform.Find("3.SuperJump").gameObject;
        if (skill)
            skill.GetComponent<SuperJump>().Start();
        skill = GameObject.Find("SkillManager").transform.Find("7.GrapringHook").gameObject;
        if (skill)
            skill.GetComponent<GrapllingContoroller>().Start();
        skill = GameObject.Find("SkillManager").transform.Find("8.Blink").gameObject;
        if (skill)
            skill.GetComponent<BlinkSkill>().Start();
    }
}
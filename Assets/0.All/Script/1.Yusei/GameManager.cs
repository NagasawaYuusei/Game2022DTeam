using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    public bool m_on { get; set; }
    public int _num;
    public bool _first;

    /// <summary>
    /// プレイヤーのHideSkillの使用したかを受け取る
    /// </summary>
    /// <param name="check"></param>
    public bool _playerHideSkillSingnal;
    public void PlayerHideSkillSignal(bool check)
    {
        if (check == false) _playerHideSkillSingnal = false;
        else if (check == true) _playerHideSkillSingnal = true;
    }

    void Start()
    {
        SkillManager.Instance.FirstSetSkill();
    }
}

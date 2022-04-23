using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    public int _num;
    public bool _first;
    public bool _isPlayerHide;

    void Start()
    {
        SkillManager.Instance.FirstSetSkill();
    }

    public void ChangePlayerHide()
    {
        _isPlayerHide = !_isPlayerHide;
    }
}

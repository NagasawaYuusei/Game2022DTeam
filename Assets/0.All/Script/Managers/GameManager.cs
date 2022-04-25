using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    private int _posNum;
    public bool _first;
    public bool _isPlayerHide;

    public int PosNum { get => _posNum; set => _posNum = value; }

    void Start()
    {
        SkillManager.Instance.FirstSetSkill();
    }

    public void ChangePlayerHide()
    {
        _isPlayerHide = !_isPlayerHide;
    }
}

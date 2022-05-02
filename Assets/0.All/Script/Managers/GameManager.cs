using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("シーン移動後のプレイヤーのポジション番号")] int _posNum;
    [Tooltip("ゲーム開始時かどうか")] bool _first;
    [Tooltip("プレイヤーがハイド状態かどうか")] bool _isPlayerHide;

    /// <summary>シーン移動後のプレイヤーのポジションの番号</summary>
    public int PosNum { get => _posNum; set => _posNum = value; }
    /// <summary>ゲーム開始時かどうか</summary>
    public bool First { get => _first; set => _first = value; }

    void Start()
    {
        //シーン移動後のスキルのセット
        SkillManager.Instance.FirstSetSkill();
    }

    /// <summary>
    /// プレイヤーのハイド状態を変更する
    /// </summary>
    public void ChangePlayerHide()
    {
        _isPlayerHide = !_isPlayerHide;
    }
}

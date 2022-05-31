using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("シーン移動後のプレイヤーのポジション番号")] int _posNum;
    [Tooltip("ゲーム開始時かどうか")] bool _first;
    [Tooltip("プレイヤーがハイド状態かどうか")] bool _isPlayerHide;
    Image _fadeImage;
    bool _isMind;
    bool[] _isKey = new bool[4];
    bool _isDead;
    bool _isUseSkill;

    /// <summary>シーン移動後のプレイヤーのポジションの番号</summary>
    public int PosNum { get => _posNum; set => _posNum = value; }
    /// <summary>ゲーム開始時かどうか</summary>
    public bool First { get => _first; set => _first = value; }

    public bool IsPlayerHide => _isPlayerHide;

    public bool IsMind => _isMind;

    public bool[] IsKey => _isKey;

    public bool IsDead => _isDead;

    public bool IsUseSkill => _isUseSkill;

    /// <summary>
    /// プレイヤーのハイド状態を変更する
    /// </summary>
    public void ChangePlayerHide()
    {
        _isPlayerHide = !_isPlayerHide;
    }

    public void ChangeMind()
    {
        _isMind = !_isMind;
    }

    public void ChangeUseSkill()
    {
        _isUseSkill = !_isUseSkill;
    }

    public void IsKeyChange(int i)
    {
        _isKey[i] = true;
    }
    public void PlayerDeath()
    {
        string str = SkillManager.Instance.NowSetSkills[SkillManager.Instance.NowSkillNum].name;
        Animator anim = GameObject.FindGameObjectWithTag("Player").transform.Find(str).GetComponent<Animator>();
        anim.SetBool("Dead", true);
        _isDead = true;
        _fadeImage = GameObject.Find("DeathImage").GetComponent<Image>();
        StartCoroutine(FadeOut());
    }

    public void ChangeRestart()
    {
        _isDead = false;
    }

    IEnumerator FadeOut()
    {
        float clearScale = 0f;
        Color currentColor = Color.white;
        while (clearScale < 1f)
        {
            clearScale += 0.5f * Time.deltaTime;
            if (clearScale >= 1f)
            {
                clearScale = 1f;
            }
            currentColor.a = clearScale;
            _fadeImage.color = currentColor;
            yield return null;
        }
    }
}

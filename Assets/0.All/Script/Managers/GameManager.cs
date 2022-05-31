using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("�V�[���ړ���̃v���C���[�̃|�W�V�����ԍ�")] int _posNum;
    [Tooltip("�Q�[���J�n�����ǂ���")] bool _first;
    [Tooltip("�v���C���[���n�C�h��Ԃ��ǂ���")] bool _isPlayerHide;
    Image _fadeImage;
    bool _isMind;
    bool[] _isKey = new bool[4];
    bool _isDead;
    bool _isUseSkill;

    /// <summary>�V�[���ړ���̃v���C���[�̃|�W�V�����̔ԍ�</summary>
    public int PosNum { get => _posNum; set => _posNum = value; }
    /// <summary>�Q�[���J�n�����ǂ���</summary>
    public bool First { get => _first; set => _first = value; }

    public bool IsPlayerHide => _isPlayerHide;

    public bool IsMind => _isMind;

    public bool[] IsKey => _isKey;

    public bool IsDead => _isDead;

    public bool IsUseSkill => _isUseSkill;

    /// <summary>
    /// �v���C���[�̃n�C�h��Ԃ�ύX����
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

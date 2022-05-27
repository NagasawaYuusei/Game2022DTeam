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

    /// <summary>�V�[���ړ���̃v���C���[�̃|�W�V�����̔ԍ�</summary>
    public int PosNum { get => _posNum; set => _posNum = value; }
    /// <summary>�Q�[���J�n�����ǂ���</summary>
    public bool First { get => _first; set => _first = value; }

    public bool IsPlayerHide => _isPlayerHide;

    /// <summary>
    /// �v���C���[�̃n�C�h��Ԃ�ύX����
    /// </summary>
    public void ChangePlayerHide()
    {
        _isPlayerHide = !_isPlayerHide;
    }

    public void PlayerDeath()
    {
        string str = SkillManager.Instance.NowSetSkills[SkillManager.Instance.NowSkillNum].name;
        Animator anim = GameObject.FindGameObjectWithTag("Player").transform.Find(str).GetComponent<Animator>();
        anim.SetBool("Dead", true);
        _fadeImage = GameObject.Find("DeathImage").GetComponent<Image>();
        StartCoroutine(FadeOut());
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

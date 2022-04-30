using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("�V�[���ړ���̃v���C���[�̃|�W�V�����ԍ�")] int _posNum;
    [Tooltip("�Q�[���J�n�����ǂ���")] bool _first;
    [Tooltip("�v���C���[���n�C�h��Ԃ��ǂ���")] bool _isPlayerHide;

    /// <summary>�V�[���ړ���̃v���C���[�̃|�W�V�����̔ԍ�</summary>
    public int PosNum { get => _posNum; set => _posNum = value; }
    /// <summary>�Q�[���J�n�����ǂ���</summary>
    public bool First { get => _first; set => _first = value; }

    void Start()
    {
        //�V�[���ړ���̃X�L���̃Z�b�g
        SkillManager.Instance.FirstSetSkill();
    }

    /// <summary>
    /// �v���C���[�̃n�C�h��Ԃ�ύX����
    /// </summary>
    public void ChangePlayerHide()
    {
        _isPlayerHide = !_isPlayerHide;
    }
}

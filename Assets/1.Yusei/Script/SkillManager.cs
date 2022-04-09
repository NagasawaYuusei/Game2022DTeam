using UnityEngine;

public class SkillManager : SingletonMonoBehaviour<SkillManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("�X�L���̏���")]int _nowSkillNum;
    [SerializeField, Tooltip("���ׂẴX�L���̃��X�g")] GameObject[] _skillList;
    [Tooltip("�Z�b�g����Ă�X�L��")]GameObject[] _nowSetSkills = new GameObject[3];
    public int NowSkillNum { get { return _nowSkillNum; } set { _nowSkillNum = value; } }
    public GameObject[] NowSetSkills { get { return _nowSetSkills; } set { _nowSetSkills = value; } }

    /// <summary>
    /// �X�L�����Z�b�g����֐�
    /// ����(int[3]):�Z�b�g�������X�L���̔ԍ�
    /// </summary>
    /// <param name="i"></param>
    public void SetSkill(int[] i)
    {
        if (i.Length != 3)
        {
            Debug.LogError("Skill�̐��͂R�ɂ��Ă�������");
            return;
        }
        for(int j = 0; j < 3; j++)
        {
            if(i[j] - 1 == -1)
            {
                _nowSetSkills[j] = null;
            }
            else
            {
                _nowSetSkills[j] = _skillList[i[j] - 1];
            }
        }
    }

    /// <summary>
    /// �X�L����ς���֐�
    /// </summary>
    public void SkillChange()
    {
        _nowSetSkills[_nowSkillNum].SetActive(false);
        _nowSkillNum++;
        if (_nowSkillNum == 3)
        {
            _nowSkillNum = 0;
        }
        _nowSetSkills[_nowSkillNum].SetActive(true);
    }

    /// <summary>
    /// �ŏ��̃X�L���ɍ��킹��֐�
    /// </summary>
    public void FirstSetSkill()
    {
        _nowSkillNum = 0;
        _nowSetSkills[_nowSkillNum].SetActive(true);
    }
}

using UnityEngine;

public class SkillManager : SingletonMonoBehaviour<SkillManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("�X�L���̏���")]int _nowSkillNum;
    [SerializeField, Tooltip("���ׂẴX�L���̃��X�g")] GameObject[] _skillList;
    [Tooltip("�Z�b�g����Ă�X�L��")]GameObject[] _nowSetSkills = new GameObject[3];
    bool _isNowSet;
    int _nowSetSkillNum;
    bool _isSkillUI;
    public int NowSkillNum { get { return _nowSkillNum; } set { _nowSkillNum = value; } }
    public GameObject[] NowSetSkills { get { return _nowSetSkills; } set { _nowSetSkills = value; } }

    public bool IsSkillUI => _isSkillUI;

    /// <summary>
    /// �X�L�����Z�b�g����֐�
    /// ����(int[3]):�Z�b�g�������X�L���̔ԍ�
    /// </summary>
    /// <param name="i"></param>
    public void SetSkills(int[] i)
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

    public void SetSkill(int i)
    {
        bool isSet = false;
        if (i == 0) return;
        if(!_isNowSet)
        {
            for(int n = 0; n < 3; n++)
            {
                if(_nowSetSkills[n] == _skillList[i - 1])
                {
                    isSet = true;
                }
            }
            if(isSet)
            {
                _nowSetSkillNum = i;
                _isNowSet = true;
            }
        }
        else if(_isNowSet && i != _nowSetSkillNum)
        {
            for (int n = 0; n < 3; n++)
            {
                if (_nowSetSkills[n] == _skillList[i - 1])
                {
                    isSet = true;
                }
            }
            if (!isSet)
            {
                int set = 0;
                for (int n = 0; n < 3; n++)
                {
                    if (_nowSetSkills[n] == _skillList[_nowSetSkillNum - 1])
                    {
                        set = n;
                    }
                }
                _nowSetSkills[set] = _skillList[i - 1];
            }
        }
    }
        
    public void SetClear()
    {
        _isNowSet = false;
        _nowSetSkillNum = 0;
    }

    public void SkillUI()
    {
        _isSkillUI = !_isSkillUI;
    }

    /// <summary>
    /// �X�L����ς���֐�
    /// </summary>
    public void SkillChange()
    {
        if (_nowSetSkills[_nowSkillNum])
            _nowSetSkills[_nowSkillNum].SetActive(false);
        _nowSkillNum++;
        if (_nowSkillNum == 3)
        {
            _nowSkillNum = 0;
        }
        if (_nowSetSkills[_nowSkillNum])
            _nowSetSkills[_nowSkillNum].SetActive(true);
    }

    /// <summary>
    /// �ŏ��̃X�L���ɍ��킹��֐�
    /// </summary>
    public void FirstSetSkill()
    {
        _nowSkillNum = 0;
        if(_nowSetSkills[_nowSkillNum])
            _nowSetSkills[_nowSkillNum].SetActive(true);
    }
}

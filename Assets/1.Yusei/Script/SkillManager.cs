using UnityEngine;

public class SkillManager : SingletonMonoBehaviour<SkillManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("スキルの順番")]int _nowSkillNum;
    [SerializeField, Tooltip("すべてのスキルのリスト")] GameObject[] _skillList;
    [Tooltip("セットされてるスキル")]GameObject[] _nowSetSkills = new GameObject[3];
    public int NowSkillNum { get { return _nowSkillNum; } set { _nowSkillNum = value; } }
    public GameObject[] NowSetSkills { get { return _nowSetSkills; } set { _nowSetSkills = value; } }

    /// <summary>
    /// スキルをセットする関数
    /// 引数(int[3]):セットしたいスキルの番号
    /// </summary>
    /// <param name="i"></param>
    public void SetSkill(int[] i)
    {
        if (i.Length != 3)
        {
            Debug.LogError("Skillの数は３つにしてください");
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
    /// スキルを変える関数
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
    /// 最初のスキルに合わせる関数
    /// </summary>
    public void FirstSetSkill()
    {
        _nowSkillNum = 0;
        _nowSetSkills[_nowSkillNum].SetActive(true);
    }
}

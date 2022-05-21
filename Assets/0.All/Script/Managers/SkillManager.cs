using UnityEngine;

public class SkillManager : SingletonMonoBehaviour<SkillManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    [Tooltip("現在のスキルの順番")] int _nowSkillNum;
    [SerializeField, Tooltip("すべてのスキルのリスト")] GameObject[] _skillList;
    [SerializeField] bool[] _canUseSkillList;
    GameObject[] _playerSkillSprites;
    [Tooltip("セットされてるスキルのゲームオブジェクト")] GameObject[] _nowSetSkills = new GameObject[3];
    bool _isNowSet;
    int _nowSetSkillNum;
    public int NowSkillNum { get { return _nowSkillNum; } set { _nowSkillNum = value; } }
    public GameObject[] NowSetSkills { get { return _nowSetSkills; } set { _nowSetSkills = value; } }
    GameObject _particle;
    [SerializeField] string _particleTag;
    [Tooltip("セットされてるスキル"), SerializeField] int[] _nowSetSkillsTest = new int[3];
    [SerializeField] bool _isDebugSetSkills;

    protected override void Awake()
    {
        base.Awake();
        SkillManager.Instance.PlayerSpriteSet();
        if (_isDebugSetSkills)
            SkillManager.Instance.SetSkills(_nowSetSkillsTest);
        SkillManager.Instance.FirstSetSkill();
    }

    public void Start()
    {
        _particle = GameObject.FindGameObjectWithTag(_particleTag);
    }

    /// <summary>
    /// スキルをセットする関数
    /// 引数(int[3]):セットしたいスキルの番号
    /// </summary>
    /// <param name="i"></param>
    public void SetSkills(int[] i)
    {
        if (i.Length != 3)
        {
            Debug.LogError("Skillの数は３つにしてください");
            return;
        }
        for (int j = 0; j < 3; j++)
        {
            if (i[j] - 1 == -1)
            {
                _nowSetSkills[j] = null;
            }
            else
            {
                _nowSetSkills[j] = _skillList[i[j] - 1];
            }
        }
    }

    public void PlayerSpriteSet()
    {
        _playerSkillSprites = new GameObject[_skillList.Length];
        for (int i = 0; i < _skillList.Length; i++)
        {
            _playerSkillSprites[i] = GameObject.FindGameObjectWithTag("Player").transform.Find(_skillList[i].name).gameObject;
        }
    }

    public void SetSkill(int i)
    {
        bool isSet = false;
        if (i == 0) return;
        if (!_isNowSet)
        {
            for (int n = 0; n < 3; n++)
            {
                if (_nowSetSkills[n] == _skillList[i - 1])
                {
                    isSet = true;
                }
            }
            if (isSet)
            {
                _nowSetSkillNum = i;
                GameObject.Find("SkillSet").GetComponent<SkillSetUseSkill>().SelectSkill(_nowSetSkillNum - 1, _isNowSet);
                _isNowSet = true;
            }
        }
        else if (_isNowSet && i != _nowSetSkillNum)
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
                GameObject.Find("SkillSet").GetComponent<SkillSetUseSkill>().SelectSkill(_nowSetSkillNum - 1, _isNowSet);
                GameObject.Find("SkillSet").GetComponent<SkillSetUseSkill>().UseingSkills();
            }
            SetClear();
        }
    }

    public void SetClear()
    {
        _isNowSet = false;
        _nowSetSkillNum = 0;
    }

    /// <summary>
    /// スキルを変える関数
    /// </summary>
    public void SkillChange()
    {
        var str = default(string[]);
        if (_nowSetSkills[_nowSkillNum])
        {
            str = _nowSetSkills[_nowSkillNum].name.Split('.');
            _nowSetSkills[_nowSkillNum].SetActive(false);
            _playerSkillSprites[int.Parse(str[0]) - 1].SetActive(false);
        }

        _nowSkillNum++;

        if (_nowSkillNum == 3)
        {
            _nowSkillNum = 0;
        }

        if (_nowSetSkills[_nowSkillNum])
        {
            str = _nowSetSkills[_nowSkillNum].name.Split('.');
            _nowSetSkills[_nowSkillNum].SetActive(true);
            _playerSkillSprites[int.Parse(str[0]) - 1].SetActive(true);
            _particle.GetComponentInParent<ParticleSystem>().Play();
        }

        PlayerController.Instance.SetAnim();
        AudioManager.Instance.SEPlay("SE", "change_skill", GameObject.FindWithTag("Player"), false, 0.3f);
    }

    /// <summary>
    /// 最初のスキルに合わせる関数
    /// </summary>
    public void FirstSetSkill()
    {
        string[] str = default(string[]);
        bool on = false;
        if (_nowSetSkills[_nowSkillNum])
        {
            on = true;
            str = _nowSetSkills[_nowSkillNum].name.Split('.');
            _nowSetSkills[_nowSkillNum].SetActive(true);
            _playerSkillSprites[int.Parse(str[0]) - 1].SetActive(true);
        }

        if (!on)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Find("0.Normal").gameObject.SetActive(true);
        }
    }

    public void ResetSkill()
    {
        for (int i = 0; i < 3; i++)
        {
            if (_nowSetSkills[i])
                _nowSetSkills[i].SetActive(false);
            _playerSkillSprites[i].SetActive(false);
        }
    }
}

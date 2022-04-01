using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    public bool m_on { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// プレイヤーのHideSkillの使用したかを受け取る
    /// </summary>
    /// <param name="check"></param>
    public bool _playerHideSkillSingnal;
    public void PlayerHideSkillSignal(bool check)
    {
        if (check == false) _playerHideSkillSingnal = false;
        else if (check == true) _playerHideSkillSingnal = true;
    }
}

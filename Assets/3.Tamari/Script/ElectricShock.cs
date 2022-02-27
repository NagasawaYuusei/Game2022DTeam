using UnityEngine;
using UnityEngine.InputSystem;

public class ElectricShock : MonoBehaviour
{
    [Header("選択できるオブジェクト")]
    [SerializeField, Tooltip("敵オブジェクト")] GameObject[] _enemys = default;
    [SerializeField, Tooltip("スイッチオブジェクト")] GameObject[] _switchs = default;

    [Tooltip("このスキルが使えるかどうか")] bool _isElectricShock = false;

    public bool IsElectricShock { get { return _isElectricShock; } set { _isElectricShock = value; } }
    
    void Start()
    {
        
    }

    /// <summary>
    /// スキル発動時に敵を止める、Lstick(Move)の操作権限をオブジェクト選択の操作に渡すためのフラグを切り替える
    /// </summary>
    void SkillOn()
    {
        //～～～～～～止める処理
        _isElectricShock = true;//操作の切り替え
    }

    /// <summary>
    /// InputSystem
    /// 操作の切り替え
    /// </summary>
    /// <param name="context"></param>
    public void Skill(InputAction.CallbackContext context)
    {
        SkillOn();
    }

    //public void Electric(InputAction.CallbackContext context)
    //{
    //    if(_isElectricShock)
    //    {
    //        for()
    //    }
    //}
}

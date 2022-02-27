using UnityEngine;
using UnityEngine.InputSystem;

public class ElectricShock : MonoBehaviour
{
    [Header("�I���ł���I�u�W�F�N�g")]
    [SerializeField, Tooltip("�G�I�u�W�F�N�g")] GameObject[] _enemys = default;
    [SerializeField, Tooltip("�X�C�b�`�I�u�W�F�N�g")] GameObject[] _switchs = default;

    [Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isElectricShock = false;

    public bool IsElectricShock { get { return _isElectricShock; } set { _isElectricShock = value; } }
    
    void Start()
    {
        
    }

    /// <summary>
    /// �X�L���������ɓG���~�߂�ALstick(Move)�̑��쌠�����I�u�W�F�N�g�I���̑���ɓn�����߂̃t���O��؂�ւ���
    /// </summary>
    void SkillOn()
    {
        //�`�`�`�`�`�`�~�߂鏈��
        _isElectricShock = true;//����̐؂�ւ�
    }

    /// <summary>
    /// InputSystem
    /// ����̐؂�ւ�
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

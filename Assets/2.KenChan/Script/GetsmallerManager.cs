using UnityEngine;
using UnityEngine.InputSystem;

public class GetsmallerManager : MonoBehaviour
{
    [Header("�������Ȃ������̑傫��")]
    [SerializeField, Tooltip("�������Ȃ������̏c�̒���")] float _changeY = 0;
    [SerializeField, Tooltip("�������Ȃ������̉��̒���")] float _changeX = 0;

    [Tooltip("�v���C���[��ScaleY��ۑ�")] float _saveY = 0;
    [Tooltip("�v���C���[��ScaleX��ۑ�")] float _saveX = 0;

    [Tooltip("�v���C���[���傫���Ȃ��Ă��邩����")] bool _scaleCheck = false;

    [SerializeField,Tooltip("���̃X�L�����g���邩�ǂ���")]bool _isSmall = true;

    public bool IsSmall { get { return _isSmall; } set { _isSmall = value; }}
    // Start is called before the first frame update
    void Start()
    {
        SaveScale();
    }

    /// <summary>
    /// �X�^�[�g���ɃI�u�W�F�N�g�̑傫����ۑ�
    /// </summary>
    void SaveScale()
    {
        _saveY = gameObject.transform.localScale.y;
        _saveX = gameObject.transform.localScale.x;
    }
    /// <summary>
    /// �v���C���[���������Ȃ鏈��
    /// </summary>
    void ChangeScale()
    {
        gameObject.transform.localScale = new Vector3(_changeX, _changeY, 1);
    }

    /// <summary>
    /// �v���C���[�����̑傫���ɖ߂�����
    /// </summary>
    void ReChangeScale()
    {
        gameObject.transform.localScale = new Vector3(_saveX, _saveY, 1);
    }

    /// <summary>
    /// InputSystem
    /// �������Ȃ�
    /// </summary>
    /// <param name="context"></param>
    public void PlayerSmallInput(InputAction.CallbackContext context)
    {
        if(_isSmall)
        {
            if (context.started && !_scaleCheck)
            {
                ChangeScale();
                _scaleCheck = true;
            }
            else if (context.started && _scaleCheck)
            {
                ReChangeScale();
                _scaleCheck = false;
            }
        }  
    }
}

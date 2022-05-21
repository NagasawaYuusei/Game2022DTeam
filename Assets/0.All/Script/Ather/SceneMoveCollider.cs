using UnityEngine;

/// <summary>
/// ����̏ꏊ�ɍs������V�[�����ړ�������N���X
/// </summary>
public class SceneMoveCollider : MonoBehaviour
{
    [Tooltip("�ړ��������V�[���̖��O"), SerializeField] string _sceneName;
    [Tooltip("�ړ��������ꏊ�̔ԍ�"), SerializeField] int _posNum;
    [Tooltip("")] bool _onTrigger;

    void Update()
    {
        if(InputSystemManager.Instance._vec1.y > 0 && _onTrigger)
        {
            GameManager.Instance.PosNum = _posNum;
            SceneController.Instance.ChangeScene(_sceneName);
            _onTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _onTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _onTrigger = false;
        }
    }
}

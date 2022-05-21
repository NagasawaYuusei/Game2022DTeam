using UnityEngine;

/// <summary>
/// ����̏ꏊ�ɍs������V�[�����ړ�������N���X
/// </summary>
public class SceneMoveCollider : MonoBehaviour
{
    [Tooltip("�ړ��������V�[���̖��O"), SerializeField] string _sceneName;
    [Tooltip("�ړ��������ꏊ�̔ԍ�"), SerializeField] int _posNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && InputSystemManager.Instance._vec1.y > 0)
        {
            GameManager.Instance.PosNum = _posNum;
            SceneController.Instance.ChangeScene(_sceneName);
        }
    }
}

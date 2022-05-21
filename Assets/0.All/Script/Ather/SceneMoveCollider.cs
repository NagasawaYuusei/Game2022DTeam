using UnityEngine;

/// <summary>
/// 特定の場所に行ったらシーンを移動させるクラス
/// </summary>
public class SceneMoveCollider : MonoBehaviour
{
    [Tooltip("移動したいシーンの名前"), SerializeField] string _sceneName;
    [Tooltip("移動したい場所の番号"), SerializeField] int _posNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && InputSystemManager.Instance._vec1.y > 0)
        {
            GameManager.Instance.PosNum = _posNum;
            SceneController.Instance.ChangeScene(_sceneName);
        }
    }
}

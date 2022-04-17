using UnityEngine;

public class SceneMove : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] int _num;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance._num = _num;
            SceneController.Instance.ChangeScene(_sceneName);
        }
    }
}

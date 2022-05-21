using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMContoroller : MonoBehaviour
{
    string _sceneName;
    public void Awake()
    {
        var a = SceneManager.GetActiveScene().name.Split('-');
        if (_sceneName == null)
        {
            _sceneName = a[0];
            return;
        }
        
        if (a[0] != _sceneName)
        {
            if(a[0] == "GirlStage1")
            {
                AudioManager.Instance.SEPlay("BGM", "syouzyonoheya", this.gameObject, true, 0.3f);
            }
            else if(a[0] == "Floor1")
            {
                AudioManager.Instance.SEPlay("BGM", "hall", this.gameObject, true, 0.3f);
            }
            else if(a[0] == "Floor3")
            {

            }
            
        }
    }
}

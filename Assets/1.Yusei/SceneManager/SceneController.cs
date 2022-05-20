using UnityEngine;

public class SceneController : SingletonMonoBehaviour<SceneController>
{
    protected override bool dontDestroyOnLoad { get { return false; } }
    void Start()
    {
        FadeController.StartFadeIn();
    }
    public void ChangeScene(string target)
    {
        SceneChange.LoadScene(target);
    }
}

using UnityEngine;

public class SceneController : SingletonMonoBehaviour<SceneController>
{
    protected override bool dontDestroyOnLoad { get { return true; } }
    void Start()
    {
        FadeController.StartFadeIn();
    }
    public void ChangeScene(string target)
    {
        SceneChange.LoadScene(target);
    }
}

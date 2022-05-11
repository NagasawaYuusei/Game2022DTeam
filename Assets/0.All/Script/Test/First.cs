using UnityEngine;

public class First : MonoBehaviour
{
    void Awake()
    {
        if(!GameManager.Instance.First)
        {
            GameManager.Instance.PosNum = 1;
            GameManager.Instance.First = true;
        }

        SkillManager.Instance.PlayerSpriteSet();
    }

    //private void Update()
    //{
    //    Debug.Log(SkillManager.Instance.NowSetSkills.Length);
    //}
}

using UnityEngine;

public class First : MonoBehaviour
{
    void Awake()
    {
        if(!GameManager.Instance._first)
        {
            GameManager.Instance.PosNum = 1;
            GameManager.Instance._first = true;
        }
    }
}

using UnityEngine;

public class Small : MonoBehaviour
{
    [SerializeField] string _playerTagName;
    [SerializeField] string _smallPlayerTagName;
    bool _isSmall;

    void Update()
    {
        SmallSkill();
    }

    void SmallSkill()
    {
        if(InputSystemManager.Instance._isSkill)
        {
            if (!_isSmall)
            {
                GameObject.FindGameObjectWithTag("Player").transform.Find("4.Small").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.Find("4.5SmallPlayerMini").gameObject.SetActive(true);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").transform.Find("4.Small").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.Find("4.5SmallPlayerMini").gameObject.SetActive(false);
            }
            _isSmall = !_isSmall;
            AudioManager.Instance.SEPlay("SE", "minimum_ver2", GameObject.FindGameObjectWithTag("Player"), false, 0.3f);
            InputSystemManager.Instance._isSkill = false;
        }
    }
}

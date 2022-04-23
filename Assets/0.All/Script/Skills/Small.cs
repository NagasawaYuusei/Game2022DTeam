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
                GameObject.FindGameObjectWithTag(_playerTagName).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag(_smallPlayerTagName).gameObject.SetActive(true);
            }
            else
            {
                GameObject.FindGameObjectWithTag(_playerTagName).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag(_smallPlayerTagName).gameObject.SetActive(false);
            }
            _isSmall = !_isSmall;
            InputSystemManager.Instance._isSkill = false;
        }
    }
}

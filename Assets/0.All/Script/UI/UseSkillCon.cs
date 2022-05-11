using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkillCon : MonoBehaviour
{
    [SerializeField] int _num;
    Image _image;
    [SerializeField] Sprite _noneSP;
    [SerializeField] Sprite _useSP;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        if(SkillManager.Instance.NowSkillNum == _num)
        {
            _image.sprite = _useSP;
        }
        else
        {
            _image.sprite = _noneSP;
        }
    }
}

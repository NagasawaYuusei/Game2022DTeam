using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillFrame : MonoBehaviour
{
    [SerializeField] Sprite[] _sp;
    Image _image;
    [SerializeField] int _frameNum;

    void Start()
    {
        _image = GetComponent<Image>();
        ChangeSprite();
    }

    private void Update()
    {
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if(!SkillManager.Instance.NowSetSkills[_frameNum])
        {
            _image.sprite = null;
            Color color = new Color(255, 255, 255, 0);
            _image.color = color;
        }
        else
        {
            var str = SkillManager.Instance.NowSetSkills[_frameNum].name.Split('.');
            Color color = new Color(255, 255, 255, 255);
            _image.sprite = _sp[int.Parse(str[0]) - 1];
            _image.color = color;
        }
    }
}

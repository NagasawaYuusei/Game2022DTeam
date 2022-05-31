using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillRule : MonoBehaviour
{
    [SerializeField, TextArea(10, 10)] string _flavorText;
    [SerializeField] Sprite _sprite;
    [SerializeField] Text _text;
    EventSystem _es;
    [SerializeField] Image _image;

    void Start()
    {
        _es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    void Update()
    {
        if(_es.currentSelectedGameObject.gameObject == gameObject)
        {
            _text.text = _flavorText;
            _image.sprite = _sprite;
        }
    }
}

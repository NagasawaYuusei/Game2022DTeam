using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSetPos : MonoBehaviour
{
    [SerializeField] string _playerTagName;
    [SerializeField] Vector2 _vec;
    bool _on;

    private void Update()
    {
        if (InputSystemManager.Instance._vec1.y > _vec.y && _on)
        {
            GameObject UI = GameObject.Find("---UI---").transform.Find("SkillSet").gameObject;
            UI.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _playerTagName)
        {
            _on = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _playerTagName)
        {
            _on = false;
        }
    }
}

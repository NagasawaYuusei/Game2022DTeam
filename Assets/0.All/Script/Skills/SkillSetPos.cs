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
        if (InputSystemManager.Instance._vec1.y > _vec.y && _on && !InputSystemManager.Instance._cantPlayerInput)
        {
            GameObject UI = GameObject.Find("---UI---").transform.Find("SkillSet").gameObject;
            InputSystemManager.Instance.ChangePlayerCanInput();
            UI.SetActive(true);
        }

        if(InputSystemManager.Instance._isJump && _on && InputSystemManager.Instance._cantPlayerInput)
        {
            InputSystemManager.Instance.ChangePlayerCanInput();
            GameObject.Find("SkillSet").gameObject.SetActive(false);
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

using System.Collections;
using UnityEngine;

public class BlinkSkill : MonoBehaviour
{
    Rigidbody2D _playerRb;
    [SerializeField] float _blinkSpeed;
    [SerializeField] float _waitTime;
    bool _firstUse;

    void Start()
    {
        Ready();
    }

    public void Ready()
    {
        _playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        BlinkReady();
    }

    void BlinkReady()
    {
        if(InputSystemManager.Instance._isSkill)
        {
            _playerRb.AddForce(InputSystemManager.Instance._vec1 * _blinkSpeed, ForceMode2D.Impulse);
            if(InputSystemManager.Instance._vec1 == Vector2.zero)
            {
                InputSystemManager.Instance._isSkill = false;
                return;
            }
            if(!_firstUse)
            {
                AudioManager.Instance.SEPlay("SE", "syunkanidou", GameObject.FindWithTag("Player"), false, 0.3f);
                _firstUse = true;
                StartCoroutine(WaitTime());
            }

        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(_waitTime);
        InputSystemManager.Instance._isSkill = false;
        _playerRb.velocity = Vector2.zero;
        _firstUse = false;
        yield return null;
    }
}

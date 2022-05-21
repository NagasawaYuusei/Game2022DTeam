using UnityEngine;

public class Psychokinesis : ObjectSelectContoroller
{
    bool on = false;
    GameObject _block = default;
    bool _isNowControl;
    Rigidbody2D _objectRb;
    [Header("設定項目")]
    [Tooltip("移動速度"), SerializeField] float _blockMoveSpeed;
    Color _originColor;
    public bool IsNowControl { get { return _isNowControl; } }



    private static Psychokinesis instance;
    public static Psychokinesis Instance
    {
        get
        {
            if (!instance)
            {
                instance = (Psychokinesis)FindObjectOfType(typeof(Psychokinesis));
                if (!instance)
                {
                    Debug.LogError("nothing");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
    }



    void Update()
    {
        PsychokinesisMove();
    }
    /// <summary>
    /// スキル発動中はブロックを動かせる
    /// </summary>
    void PsychokinesisMove()
    {
        if (InputSystemManager.Instance._isSkill && !_isNowControl)
        {
            Select("PsychokinesisObject");
            _block = First();
            if(_block)
            {
                _objectRb = _block.GetComponent<Rigidbody2D>();
                _objectRb.gravityScale = 0;
                _objectRb.mass = 1;
                _objectRb.constraints = RigidbodyConstraints2D.None;

                _originColor = _block.GetComponent<SpriteRenderer>().color;
                _block.GetComponent<SpriteRenderer>().color = Color.yellow;

                _isNowControl = true;
            }
            InputSystemManager.Instance._isSkill = false;
            AudioManager.Instance.SEPlay("SE", "nenriki", GameObject.FindGameObjectWithTag("Player"), true, 0.04f);
        }
        else if (InputSystemManager.Instance._isSkill && _isNowControl)
        {
            _block.GetComponent<SpriteRenderer>().color = _originColor;
            _isNowControl = false;

            _objectRb.velocity = Vector2.zero;
            _objectRb.gravityScale = 1;
            _objectRb.mass = 100;
            _objectRb.constraints = RigidbodyConstraints2D.FreezePositionX;
            InputSystemManager.Instance._isSkill = false;
            AudioManager.Instance.SEStop(GameObject.FindGameObjectWithTag("Player"));
        }

        if (_isNowControl)
        {
            if (InputSystemManager.Instance._vec2.y > 0 && !on)
            {
                _objectRb.gravityScale = 1;
                _objectRb.mass = 100;
                _objectRb.constraints = RigidbodyConstraints2D.FreezePositionX;
                _block.GetComponent<SpriteRenderer>().color = _originColor;
                _block = Change(1);
                _objectRb = _block.GetComponent<Rigidbody2D>();
                _objectRb.gravityScale = 0;
                _objectRb.mass = 1;
                _objectRb.constraints = RigidbodyConstraints2D.None;
                _originColor = _block.GetComponent<SpriteRenderer>().color;
                _block.GetComponent<SpriteRenderer>().color = Color.yellow;
                on = true;
            }
            else if (InputSystemManager.Instance._vec2.y < 0 && !on)
            {
                _objectRb.gravityScale = 1;
                _objectRb.mass = 100;
                _objectRb.constraints = RigidbodyConstraints2D.FreezePositionX;
                _block.GetComponent<SpriteRenderer>().color = _originColor;
                _block = Change(-1);
                _objectRb = _block.GetComponent<Rigidbody2D>();
                _objectRb.gravityScale = 0;
                _objectRb.mass = 1;
                _objectRb.constraints = RigidbodyConstraints2D.None;

                _originColor = _block.GetComponent<SpriteRenderer>().color;
                _block.GetComponent<SpriteRenderer>().color = Color.yellow;

                on = true;
            }
            else if (InputSystemManager.Instance._vec2.y == 0 && on)
            {
                on = false;
            }
            ObjectMove();
        }
    }

    void ObjectMove()
    {
        _objectRb.velocity = InputSystemManager.Instance._vec1 * _blockMoveSpeed;
    }
}

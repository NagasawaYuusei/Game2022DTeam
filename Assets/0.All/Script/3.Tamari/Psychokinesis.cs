using UnityEngine;

public class Psychokinesis : ObjectSelectContoroller
{
    bool on = false;
    GameObject _block = default;
    bool _isNowControl;
    [Tooltip("ブロックのRb")] Rigidbody2D _blockRb;
    [Tooltip("InputSystemの移動入力")] Vector2 _blockVec;
    [Header("設定項目")]
    [Tooltip("移動速度"), SerializeField] float _blockMoveSpeed;

    [Tooltip("このスキルが使えるかどうか")] bool _isPsychokinesis = true;

    Color _originColor;

    public bool IsPsychokinesis { get { return _isPsychokinesis; } set { _isPsychokinesis = value; } }
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



    private void Update()
    {
        PsychokinesisMove();
    }
    /// <summary>
    /// スキル発動中はブロックを動かせる
    /// </summary>
    void PsychokinesisMove()
    {
        if (!_isPsychokinesis) return;
        if (InputSystemManager.Instance._isSkill && !_isNowControl)
        {
            Select("Object");
            _block = First();
            _block.GetComponent<Rigidbody2D>().gravityScale = 0;
            _block.GetComponent<Rigidbody2D>().mass = 1;
            _block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            _originColor = _block.GetComponent<SpriteRenderer>().color;
            _block.GetComponent<SpriteRenderer>().color = Color.yellow;
            _isNowControl = true;
            InputSystemManager.Instance._isSkill = false;
        }
        else if (InputSystemManager.Instance._isSkill && _isNowControl)
        {
            _block.GetComponent<SpriteRenderer>().color = _originColor;
            _isNowControl = false;
            _block.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _block.GetComponent<Rigidbody2D>().gravityScale = 1;
            _block.GetComponent<Rigidbody2D>().mass = 100;
            _block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            InputSystemManager.Instance._isSkill = false;
        }

        if (_isNowControl)
        {
            if (InputSystemManager.Instance._vec2.y > 0 && !on)
            {
                _block.GetComponent<Rigidbody2D>().gravityScale = 1;
                _block.GetComponent<Rigidbody2D>().mass = 100;
                _block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                _block.GetComponent<SpriteRenderer>().color = _originColor;
                _block = Change(1);
                _block.GetComponent<Rigidbody2D>().gravityScale = 0;
                _block.GetComponent<Rigidbody2D>().mass = 1;
                _block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                _originColor = _block.GetComponent<SpriteRenderer>().color;
                _block.GetComponent<SpriteRenderer>().color = Color.yellow;
                on = true;
            }
            else if (InputSystemManager.Instance._vec2.y < 0 && !on)
            {
                _block.GetComponent<Rigidbody2D>().gravityScale = 1;
                _block.GetComponent<Rigidbody2D>().mass = 100;
                _block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                _block.GetComponent<SpriteRenderer>().color = _originColor;
                _block = Change(-1);
                _block.GetComponent<Rigidbody2D>().gravityScale = 0;
                _block.GetComponent<Rigidbody2D>().mass = 1;
                _block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
        _block.GetComponent<Rigidbody2D>().velocity = InputSystemManager.Instance._vec1 * _blockMoveSpeed;
    }
}

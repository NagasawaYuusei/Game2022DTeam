using UnityEngine;

public class SuperJump : SingletonMonoBehaviour<SuperJump>
{
    protected override bool dontDestroyOnLoad {get {return false;}}
    [SerializeField] float _jumpUpValue = 1.5f;
    [SerializeField] float _flowValue = 0.5f;
    Rigidbody2D _playerRb;
    void Start()
    {
        _playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flow();
    }

    void Flow()
    {
        if(!PlayerController.Instance.IsGrounded())
        {
            _playerRb.gravityScale = _flowValue;
        }
    }

    public void SuperJumpMethod()
    {
        _playerRb.velocity = Vector2.up * PlayerController.Instance.JumpSpeed * _jumpUpValue;
    }
}

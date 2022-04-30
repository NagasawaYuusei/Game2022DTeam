using UnityEngine;

public class GrapllingContoroller : ObjectSelectContoroller
{
    LineRenderer _lr;
    GameObject _player;
    GameObject _grappleObject;
    bool _isCurrentSelect;
    [SerializeField] float _grapSpeed = 5;

    Rigidbody2D _playerRb;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _lr = _player.GetComponent<LineRenderer>();
        _playerRb = _player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadyGrapple();
        StartGrapple();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void ReadyGrapple()
    {
        if (InputSystemManager.Instance._isSkill && !_isCurrentSelect)
        {
            Select("Finish");
            _grappleObject = First();
            _isCurrentSelect = true;
            _lr.positionCount = 2;
        }
        else if(!InputSystemManager.Instance._isSkill && _isCurrentSelect)
        {
            _grappleObject = null;
            _isCurrentSelect = false;
            StopGrapple();
        }
    }

    void StartGrapple()
    {
        if (!_isCurrentSelect) return;

        Vector3 dir = _grappleObject.transform.position - _player.transform.position;
        dir = new Vector2(dir.x, dir.y);
        _playerRb.AddForce(dir * _grapSpeed, ForceMode2D.Force);
         
        if(_playerRb.velocity.x > 20)
            InputSystemManager.Instance._isSkill = false;
    }

    void StopGrapple()
    {
        _lr.positionCount = 0;
    }

    void DrawRope()
    {
        if (!_grappleObject) return;
        _lr.SetPosition(0, _player.transform.position);
        _lr.SetPosition(1, _grappleObject.transform.position);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class MindControl : MonoBehaviour
{
    [Header("���삷��G�l�~�[���i�[")]
    [SerializeField, Tooltip("���]�����G�l�~�[")] GameObject _mindEnemy;
    [Tooltip("�G�l�~�[��Rigidbody")] Rigidbody2D _rb2d;
    [Tooltip("�G�l�~�[��Vector2")] Vector2 _enemyVec;

    [Header("�G�l�~�[�̈ړ����x")]
    [SerializeField, Tooltip("�G�l�~�[�̈ړ����x")] float _enemySpeed;

    [SerializeField, Tooltip("���̃X�L�����g���邩�ǂ���")] bool _isMindControl = true;
    public bool IsMindControl { get { return _isMindControl; } set { _isMindControl = value; } }

    void Start()
    {
        _mindEnemy = GameObject.FindWithTag("Enemy");
        _rb2d = _mindEnemy.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyMindControl();
    }

    /// <summary>
    /// InputSystem
    /// �G�𑀍삷��
    /// </summary>
    void EnemyMindControl()
    {
        if (InputSystemManager.Instance._isSkill && _isMindControl)
        {
            _rb2d.velocity = new Vector2(_enemySpeed * _enemyVec.x, _rb2d.velocity.y);
        }
    }
}

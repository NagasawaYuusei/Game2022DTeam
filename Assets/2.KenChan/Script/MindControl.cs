using UnityEngine;
using UnityEngine.InputSystem;

public class MindControl : MonoBehaviour
{
    [Header("操作するエネミーを格納")]
    [SerializeField, Tooltip("洗脳したエネミー")] GameObject _mindEnemy;
    [Tooltip("エネミーのRigidbody")] Rigidbody2D _rb2d;
    [Tooltip("エネミーのVector2")] Vector2 _enemyVec;

    [Header("エネミーの移動速度")]
    [SerializeField, Tooltip("エネミーの移動速度")] float _enemySpeed;

    [SerializeField, Tooltip("このスキルが使えるかどうか")] bool _isMindControl = true;
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
    /// 敵を操作する
    /// </summary>
    void EnemyMindControl()
    {
        if (InputSystemManager.Instance._isSkill && _isMindControl)
        {
            _rb2d.velocity = new Vector2(_enemySpeed * _enemyVec.x, _rb2d.velocity.y);
        }
    }
}

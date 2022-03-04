using UnityEngine;
using UnityEngine.InputSystem;

public class Psychokinesis : MonoBehaviour
{
    [SerializeField] GameObject _block = default;
    [Tooltip("ブロックのRb")] Rigidbody2D _blockRb;
    [Tooltip("InputSystemの移動入力")] Vector2 _blockVec;
    [Header("設定項目")]
    [Tooltip("移動速度"), SerializeField] float _blockMoveSpeed;

    [Tooltip("このスキルが使えるかどうか")] bool _isPsychokinesis = false;

    public bool IsPsychokinesis { get { return _isPsychokinesis; } set { _isPsychokinesis = value; } }

    private void Update()
    {
        PsychokinesisMove();
    }
    /// <summary>
    /// スキル発動中はブロックを動かせる
    /// </summary>
    void PsychokinesisMove()
    {
        if (_isPsychokinesis)
        {
            _blockRb = GetComponent<Rigidbody2D>();
            _blockRb.velocity = new Vector2(_blockMoveSpeed * _blockVec.x, _blockMoveSpeed * _blockRb.velocity.y);
        }
    }

    /// <summary>
    /// InputSystem
    /// ブロックの移動
    /// </summary>
    /// <param name="context"></param>
    public void BlockMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _blockVec = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _blockVec = Vector2.zero;
        }
    }
}

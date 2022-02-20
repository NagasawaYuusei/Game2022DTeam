using UnityEngine;
using UnityEngine.InputSystem;

public class GetsmallerManager : MonoBehaviour
{
    [Header("小さくなった時の大きさ")]
    [SerializeField, Tooltip("小さくなった時の縦の長さ")] float _changeY = 0;
    [SerializeField, Tooltip("小さくなった時の横の長さ")] float _changeX = 0;

    [Tooltip("プレイヤーのScaleYを保存")] float _saveY = 0;
    [Tooltip("プレイヤーのScaleXを保存")] float _saveX = 0;

    [Tooltip("プレイヤーが大きくなっているか判別")] bool _scaleCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        SaveScale();
    }

    /// <summary>
    /// スタート時にオブジェクトの大きさを保存
    /// </summary>
    void SaveScale()
    {
        _saveY = gameObject.transform.localScale.y;
        _saveX = gameObject.transform.localScale.x;
    }
    /// <summary>
    /// プレイヤーが小さくなる処理
    /// </summary>
    void ChangeScale()
    {
        gameObject.transform.localScale = new Vector3(_changeX, _changeY, 1);
    }

    /// <summary>
    /// プレイヤーを元の大きさに戻す処理
    /// </summary>
    void ReChangeScale()
    {
        gameObject.transform.localScale = new Vector3(_saveX, _saveY, 1);
    }

    /// <summary>
    /// InputSystem
    /// 小さくなる
    /// </summary>
    /// <param name="context"></param>
    public void PlayerSmallInput(InputAction.CallbackContext context)
    {
        if (context.started && !_scaleCheck)
        {
            ChangeScale();
            _scaleCheck = true;
        }
        else if(context.started && _scaleCheck)
        {
            ReChangeScale();
            _scaleCheck = false;
        }
    }
}

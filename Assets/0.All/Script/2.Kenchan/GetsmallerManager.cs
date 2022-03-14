using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class GetsmallerManager : MonoBehaviour
{
    [Header("小さくなった時の大きさ")]
    [SerializeField, Tooltip("小さくなった時の縦の長さ")] float _changeY = 0;
    [SerializeField, Tooltip("小さくなった時の横の長さ")] float _changeX = 0;

    [Header("変更中の時間")]
    [SerializeField, Tooltip("大きさの変更時間")] float _changeTime;

    [Tooltip("プレイヤーのScaleYを保存")] float _saveY = 0;
    [Tooltip("プレイヤーのScaleXを保存")] float _saveX = 0;

    [Tooltip("プレイヤーが大きくなっているか判別")] bool _scaleCheck = false;

    [SerializeField,Tooltip("このスキルが使えるかどうか")]bool _isSmall = true;

    public bool IsSmall { get { return _isSmall; } set { _isSmall = value; }}
    // Start is called before the first frame update
    void Start()
    {
        SaveScale();
    }

    void Update()
    {
        Small();
    }
    /// <summary>
    /// スタート時にオブジェクトの大きさを保存
    /// </summary>
    void SaveScale()
    {
        _saveY = gameObject.transform.localScale.y;
        _saveX = gameObject.transform.localScale.x;
    }

    void Small()
    {
        if (!_isSmall) return;
        if(InputSystemManager.Instance._isSkill && !_scaleCheck)
        {
            ChangeScale();
            InputSystemManager.Instance._isSkill = false;
            _scaleCheck = true;
        }
        else if(InputSystemManager.Instance._isSkill && _scaleCheck)
        {
            ReChangeScale();
            InputSystemManager.Instance._isSkill = false;
            _scaleCheck = false;
        }
    }
    /// <summary>
    /// プレイヤーが小さくなる処理
    /// </summary>
    void ChangeScale()
    {
        gameObject.transform.DOScale(new Vector3(_changeX, _changeY, 1), _changeTime);
    }

    /// <summary>
    /// プレイヤーを元の大きさに戻す処理
    /// </summary>
    void ReChangeScale()
    {
        gameObject.transform.DOScale(new Vector3(_saveX, _saveY, 1), _changeTime);
    }
}

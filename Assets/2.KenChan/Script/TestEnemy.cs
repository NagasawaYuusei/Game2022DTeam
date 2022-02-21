using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class TestEnemy : MonoBehaviour
{
    [Header("エネミーの停止時間")]
    [SerializeField, Tooltip("Enemyが止まっている時間")] float _stopTime;

    [Tooltip("画面内に敵がいるかどうか")] bool _isInsideCamera;

    [Tooltip("エネミーのRigidbody2D")] Rigidbody2D _rb2d;
    [Tooltip("プレイヤーを取得")] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        _rb2d.velocity = new Vector2 (-1, 0); //エネミーの移動を簡易的に行っているだけ
    }

    /// <summary>
    /// カメラ内に入ったか出たかどうか
    /// </summary>
    void OnWillRenderObject()
    {
        if (Camera.current.name == "Main Camera")
        {
            _isInsideCamera = true;

        }
        else
        {
            _isInsideCamera = false;
        }
    }

    /// <summary>
    /// 止まっている時間
    /// </summary>
    /// <returns></returns>
    IEnumerator ReMoveCount()
    {
        yield return new WaitForSeconds(_stopTime);
        _player.GetComponent<GetMedusaManager>()._medusaCheck = false;
        _rb2d.constraints = RigidbodyConstraints2D.None;
    }

    /// <summary>
    /// プレイヤーがメデゥーサを発動したか確認して、Enemyの動きを止める
    /// </summary>
    /// <param name="context"></param>
    public void PlayerMedusaInput(InputAction.CallbackContext context)
    {
        if (context.started && _player.GetComponent<GetMedusaManager>()._medusaCheck == true)
        {
            if (_isInsideCamera)
            {
                _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;//Rigidbody2DのFreezeを全てオンにしている
                StartCoroutine("ReMoveCount");
            }
        }
    }
}

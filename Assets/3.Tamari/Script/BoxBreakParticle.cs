using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreakParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;
    [SerializeField] Renderer _rend;
    [Tooltip("オブジェクトが消えるまでの時間"), SerializeField] float _destroyTime = 2f;
   
    /// <summary>
    /// Startでのセットアップ
    /// </summary>
    /// <param name="context"></param>
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
    }

    /// <summary>
    /// 箱が壊れた時にパーティクルを出す
    /// </summary>
    /// <param name="context"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _particle.Play();
            _rend.enabled = false;
            Destroy(gameObject,_destroyTime);
        }
    }
}

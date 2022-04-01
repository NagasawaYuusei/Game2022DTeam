using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreakParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;
    [SerializeField] Renderer _rend;
    [Tooltip("�I�u�W�F�N�g��������܂ł̎���"), SerializeField] float _destroyTime = 2f;
   
    /// <summary>
    /// Start�ł̃Z�b�g�A�b�v
    /// </summary>
    /// <param name="context"></param>
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
    }

    /// <summary>
    /// ������ꂽ���Ƀp�[�e�B�N�����o��
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapllingContoroller : MonoBehaviour
{
    [Tooltip("Grap���苗��"), SerializeField] float m_grapRange;
    [Tooltip("Ray��Gizmo�\��"), SerializeField] bool m_onRay;
    [Tooltip("�|�C���g�̃��C���[�ԍ�"), SerializeField] int m_pointLayerValue;
    [Tooltip("�v���C���[��Rigidbody"), SerializeField] Rigidbody m_playerRb;
    [Tooltip("�߂��ɂ���Ɣ��肷�鋗��"), SerializeField] float m_pointNearRange = 5;
    [Tooltip("�O���b�v�����O�̃p���["), SerializeField] float m_grapPower;
    [Tooltip("Y���ɂ�������ʂȗ�"), SerializeField] float m_yPower;
    [Tooltip("���������I�u�W�F�N�g�𔻒肷�����")] RaycastHit m_hit;
    [Tooltip("�O���b�v�����O�����ǂ���")] bool m_onGrapple = false;
    [Tooltip("���������I�u�W�F�N�g�̃g�����X�t�H�[��")] Transform m_hitTransform;

    [SerializeField] LineRenderer m_lr;
    [SerializeField] Transform m_gunTransform;
    public bool OnGrapple { get { return m_onGrapple; } }
    public Vector3 GetGrapplePoint { get { return m_hitTransform.position; } }


    void Update()
    {
        GrapCheck();
    }

    void FixedUpdate()
    {
        AddPowerReady();
    }

    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// GrapInputSystem�����@�f�t�H���g�@�E�N���b�N
    /// </summary>
    /// <param name="context"></param>
    //public void PlayerGrap(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //    {
    //        PointHit();
    //    }

    //    if (context.canceled)
    //    {
    //        m_onGrapple = false;
    //    }
    //}

    /// <summary>
    /// �|�C���g�����邩�ǂ����̏���
    /// </summary>
    void PointHit()
    {
        bool hit = Physics.Raycast(transform.position, transform.forward, out m_hit, m_grapRange);
        Debug.DrawRay(transform.position, transform.forward * m_grapRange, Color.blue);
        if (hit && !m_onGrapple)
        {
            if (m_hit.collider.gameObject.layer == m_pointLayerValue)
            {
                m_hitTransform = m_hit.collider.gameObject.transform;
                m_lr.enabled = true;
                m_lr.positionCount = 2;
                m_onGrapple = true;
            }
            else
            {
                hit = false;
                return;
            }
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Grappling�ł��邩�̏���
    /// </summary>
    void GrapCheck()
    {
        if (m_onRay)
        {
            PointHit();
        }
    }

    void AddPowerReady()
    {
        if (m_onGrapple)
        {
            AddPower();
        }
    }

    /// <summary>
    /// Grap����
    /// </summary>
    void AddPower()
    {
        Vector3 dir = m_hitTransform.position - transform.position;
        dir = new Vector3(dir.x, dir.y * m_yPower, dir.z);
        m_playerRb.AddForce(dir * m_grapPower, ForceMode.Force);
    }

    /// <summary>
    /// GrapPoint�Ƃ̋�����Bool�ŕԂ�
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="pointTransform"></param>
    /// <returns></returns>
    bool isNear(Transform transform, Transform pointTransform)
    {
        float dis = Vector3.Distance(transform.position, pointTransform.position);
        if (dis < m_pointNearRange)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ������
    /// </summary>
    void DrawRope()
    {
        if (!m_onGrapple)
        {
            m_lr.enabled = false;
            return;
        }
        m_lr.SetPosition(0, m_gunTransform.position);
        m_lr.SetPosition(1, m_hitTransform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] Vector3 m_targetPos;
    [SerializeField] Image m_aimImage;

    private void Start()
    {
        //m_player = GameObject.FindWithTag("Player");
    }
    void OnEnable()
    {
        // �}�E�X�J�[�\��������
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }
    void Update()
    {
        // �u�}�E�X�̈ʒu�v�Ɓu�Ə���̈ʒu�v�𓯊�������B
        transform.position = Input.mousePosition;

        RaycastHit hit;

        // MainCamera����}�E�X�̈ʒu��Ray���΂�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Ray��Collider�ƏՓ˂����n�_�̍��W���擾
            m_targetPos = hit.point;
            //print(m_targetPos);

            if (hit.transform.CompareTag("Enemy"))
            {
                // �Ə����ԐF�ɕω�������B
                //Debug.Log("Enemy");
                m_aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else if(hit.transform.CompareTag("Switch"))
            {
                m_aimImage.color = new Color(1.0f, 0.92f, 0.016f, 1.0f);
            }
            else
            {
                // �Ə���̐F�͔�
                m_aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }

        }


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpown : MonoBehaviour
{
    [Header("�X�|�[�����������I�u�W�F�N�g")]
    [SerializeField, Tooltip("�X�|�[�����������I�u�W�F�N�g")] GameObject _spownObj;

    [Header("�X�|�[��������Ԋu")]
    [SerializeField, Tooltip("�X�|�[�������鎞�ԊԊu")] int _spownTime;

    [Tooltip("�X�|�[��������Transform")] Transform _spownTransform;

    private void Start()
    {
        _spownTransform = this.gameObject.GetComponent<Transform>();

        StartCoroutine(SpownObj(_spownTime));
    }


    /// <summary>
    /// �X�|�[������莞�Ԃ��ƂɌĂяo��
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    IEnumerator SpownObj(int i)
    {
        yield return new WaitForSeconds(i);
        Instantiate(_spownObj, _spownTransform.position, Quaternion.identity);
        StartCoroutine(SpownObj(_spownTime));
    }

}

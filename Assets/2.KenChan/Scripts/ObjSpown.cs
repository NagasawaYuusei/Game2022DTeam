using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpown : MonoBehaviour
{
    [Header("スポーンさせたいオブジェクト")]
    [SerializeField, Tooltip("スポーンさせたいオブジェクト")] GameObject _spownObj;

    [Header("スポーンさせる間隔")]
    [SerializeField, Tooltip("スポーンさせる時間間隔")] int _spownTime;

    [Tooltip("スポーンさせるTransform")] Transform _spownTransform;

    private void Start()
    {
        _spownTransform = this.gameObject.GetComponent<Transform>();

        StartCoroutine(SpownObj(_spownTime));
    }


    /// <summary>
    /// スポーンを一定時間ごとに呼び出す
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

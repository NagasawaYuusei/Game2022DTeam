using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectContoroller : MonoBehaviour
{
    List<GameObject> _goList = new List<GameObject>();
    int _nowNum = 0;
    protected virtual void Select(string tag)
    {
        List<int> intList = new List<int>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag(tag);
        _goList.Clear();
        _goList.AddRange(gos);

        for(int i = 0; i < _goList.Count; i++)
        {
            if(!_goList[i].GetComponent<IsEnemyInCamera>().IsEnemyInCameraState)
            {
                intList.Add(i);
            }
        }

        for(int i = 0; i < intList.Count; i++)
        {
            _goList.RemoveAt(intList[i]);
        }
        _nowNum = 0;
        print(_goList.Count);
    }
    
    protected virtual GameObject First()
    {
        return _goList[_nowNum];
    }

    protected virtual GameObject Change(int i)
    {
        if (_nowNum + i > 0 || _nowNum + i < _goList.Count - 1)
        {
            _nowNum += i;
        }
        print(_nowNum);
        return _goList[_nowNum];
    }
}

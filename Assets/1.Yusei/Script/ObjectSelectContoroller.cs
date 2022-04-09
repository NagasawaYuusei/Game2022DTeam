using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectContoroller : SkillBase
{
    List<GameObject> _goList;
    int _nowNum;

    protected virtual void Select(string tag)
    {
        List<GameObject> goList = new List<GameObject>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag(tag);
        _goList.Clear();
        _goList.AddRange(gos);

        if (_goList.Count != 0)
        {
            for (int i = 0; i < _goList.Count; i++)
            {
                if (!_goList[i].GetComponent<IsEnemyInCamera>().IsEnemyInCameraState)
                {
                    goList.Add(_goList[i]);
                }
            }
        }

        if (goList.Count != 0 && _goList.Count != 0)
        {
            for (int i = 0; i < goList.Count; i++)
            {
                _goList.Remove(goList[i]);
            }
        }
        _nowNum = 0;
    }

    protected virtual GameObject First()
    {
        return _goList[_nowNum];
    }

    protected virtual GameObject Change(int i)
    {
        if (_nowNum + i > 0 && _nowNum + i < _goList.Count - 1)
        {
            _nowNum += i;
        }
        return _goList[_nowNum];
    }
}

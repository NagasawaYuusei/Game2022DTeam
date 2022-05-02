using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFirst : MonoBehaviour
{
    [SerializeField] Button _button;

    private void Start()
    {
        _button.Select();
    }
}

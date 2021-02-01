using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HaKoLibrary;

public class ValueScnDisplay : MonoBehaviour
{
    [SerializeField] private ValueScn _testingScn;
    [SerializeField] private TextMeshProUGUI _tmpValue;

    private void Display(ScientificNotation value)
    {
        _tmpValue.text = value.ToString();
    }

    private void OnEnable()
    {
        _testingScn.OnChangeValue += Display;
    }

    private void OnDisable()
    {
        _testingScn.OnChangeValue -= Display;
    }
}

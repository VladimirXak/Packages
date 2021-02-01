using UnityEngine;
using HaKoLibrary;
using System;
using UnityEngine.UI;

public class ValueScn : MonoBehaviour
{
    [SerializeField] private Button _nextValueButton;
    [Space(10)]
    [SerializeField] private ScientificNotation _startValue;
    [SerializeField] private ScientificNotation _coefficient;
    [SerializeField] private int _startPower;

    public Action<ScientificNotation> OnChangeValue;

    private ScientificNotation _value;
    private ScientificNotation Value
    {
        get => _value;
        set
        {
            _value = value;
            OnChangeValue?.Invoke(_value);
        }
    }

    private void Awake()
    {
        _nextValueButton.onClick.AddListener(NextValue);
    }

    private void Start()
    {
        Value = _startValue * ScientificNotation.Pow(_coefficient, _startPower);
    }

    private void NextValue()
    {
        Value *= _coefficient;
    }
}


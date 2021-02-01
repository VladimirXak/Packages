using HaKoLibrary;
using System;
using UnityEngine;

public class ValueProgressBar : MonoBehaviour
{
    [SerializeField] private ProgressBarScienificNotation _pbsn;
    [SerializeField] private ScientificNotation _startValue;
    [SerializeField] private ScientificNotation _subValue;

    public event Action<ScientificNotation> OnChange;

    private ScientificNotation _value;
    private ScientificNotation Value
    {
        get => _value;
        set
        {
            _value = value;
            OnChange?.Invoke(_value);
        }
    }

    private void Awake()
    {
        Value = _startValue;
        _pbsn.MaxValue = Value;
        _pbsn.ChangeDisplay(Value);
    }

    public void Update()
    {
        if (Value.IsZero())
        {
            Value = _startValue;
            _pbsn.ChangeDisplay(Value);
            return;
        }

        Value -= _subValue;
        _pbsn.ChangeDisplay(Value);
    }
}

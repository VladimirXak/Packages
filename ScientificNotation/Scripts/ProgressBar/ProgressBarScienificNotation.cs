using HaKoLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScienificNotation : MonoBehaviour
{
    [SerializeField] private Image _imgProgressBar;

    private ScientificNotation _maxValue;
    public ScientificNotation MaxValue
    {
        get => _maxValue;
        set
        {
            if (value < 0)
                _maxValue = 0;
            else
                _maxValue = value;
        }
    }

    public void ChangeDisplay(ScientificNotation value)
    {
        if (_maxValue.IsZero())
        {
            _imgProgressBar.fillAmount = 0;
            return;
        }

        if (value >= _maxValue)
        {
            _imgProgressBar.fillAmount = 1;
            return;
        }

        ScientificNotation scnFillAmount = (value / _maxValue);

        float fillAmount = (float)(scnFillAmount.Mantissa * System.Math.Pow(10, scnFillAmount.Order));

        _imgProgressBar.fillAmount = fillAmount;
    }

    public void ResetProgress()
    {
        _imgProgressBar.fillAmount = 1;
    }
}

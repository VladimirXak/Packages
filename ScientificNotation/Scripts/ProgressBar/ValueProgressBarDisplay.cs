using UnityEngine;
using TMPro;
using HaKoLibrary;

public class ValueProgressBarDisplay : MonoBehaviour
{
    [SerializeField] private ValueProgressBar _testingProgressBar;
    [SerializeField] private TextMeshProUGUI _tmpValue;

    private void Display(ScientificNotation value)
    {
        _tmpValue.text = value.ToString();
    }

    private void OnEnable()
    {
        _testingProgressBar.OnChange += Display;
    }

    private void OnDisable()
    {
        _testingProgressBar.OnChange -= Display;
    }
}

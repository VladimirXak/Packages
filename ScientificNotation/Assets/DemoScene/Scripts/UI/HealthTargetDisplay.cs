using UnityEngine;
using TMPro;
using HakoLibrary.Scn;

namespace HakoLibrary.Demo.UI
{
    public class HealthTargetDisplay : MonoBehaviour
    {
        [SerializeField] private Target _target;
        [SerializeField] private TextMeshProUGUI _tmpHealth;

        private void Render(ScientificNotation value)
        {
            _tmpHealth.text = value.ToString();
        }

        private void OnEnable()
        {
            _target.OnChange += Render;
        }

        private void OnDisable()
        {
            _target.OnChange -= Render;
        }
    }
}

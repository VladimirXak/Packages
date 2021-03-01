using HakoLibrary.Scn;
using System;
using UnityEngine;

namespace HakoLibrary.Demo.UI
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private ScientificNotation _startHealth;
        [SerializeField] private ScientificNotation _healthCoefficient;
        [Space(10)]
        [SerializeField] private ProgressBarScienificNotation _progressBar;

        public Action<ScientificNotation> OnChange;

        private ScientificNotation _staticCurrentHealth;

        private ScientificNotation _currentHealth;
        private ScientificNotation CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                OnChange?.Invoke(value);
            }
        }

        private void Awake()
        {
            _staticCurrentHealth = _startHealth;
            CurrentHealth = _staticCurrentHealth;
        }

        public void GetDamage(ScientificNotation damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth.IsZero())
                RecalculateHealth();

            _progressBar.ChangeDisplay(CurrentHealth);
        }

        private void RecalculateHealth()
        {
            _staticCurrentHealth *= _healthCoefficient;
            CurrentHealth = _staticCurrentHealth;

            _progressBar.MaxValue = CurrentHealth;
        }
    }
}

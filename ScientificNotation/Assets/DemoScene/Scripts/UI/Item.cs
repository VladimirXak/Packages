using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HakoLibrary.Scn;

namespace HakoLibrary.Demo.UI
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ScientificNotation _startDamage;
        [SerializeField] private ScientificNotation _damageCoefficient;
        [Space(10)]
        [SerializeField] private Target _target;
        [SerializeField] private TextMeshProUGUI _tmpDamage;
        [SerializeField] private TextMeshProUGUI _tmpLevelUpgrade;
        [Space(10)]
        [SerializeField] private Button _upgradeButton;

        private int _levelUpgrade = 1;

        private ScientificNotation _currentDamage;

        private void Awake()
        {
            _upgradeButton.onClick.AddListener(Upgrade);

            _currentDamage = _startDamage;

            RenderInformation();
        }

        private void Upgrade()
        {
            _currentDamage *= _damageCoefficient;
            _levelUpgrade++;

            RenderInformation();
        }

        private void RenderInformation()
        {
            _tmpDamage.text = _currentDamage.ToString();
            _tmpLevelUpgrade.text = _levelUpgrade.ToString();
        }

        private void ToDamage()
        {
            _target.GetDamage(_currentDamage);
        }

        private void OnEnable()
        {
            TapOnTarget.OnTap += ToDamage;
        }

        private void OnDisable()
        {
            TapOnTarget.OnTap -= ToDamage;
        }
    }
}

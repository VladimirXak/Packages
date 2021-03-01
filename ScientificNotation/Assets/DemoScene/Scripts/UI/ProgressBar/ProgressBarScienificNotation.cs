using HakoLibrary.Scn;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HakoLibrary.Demo.UI
{
    public class ProgressBarScienificNotation : MonoBehaviour
    {
        [SerializeField] private Image _imgProgressBar;
        [Space(10)]
        [SerializeField] private bool _isAnimated;
        [SerializeField] private float _timeAnimation = 0.25f;

        private Coroutine _coroutineAnimationBar;

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
                ResetProgress();
                return;
            }

            ScientificNotation scnFillAmount = (value / _maxValue);

            float fillAmount = (float)(scnFillAmount.Mantissa * System.Math.Pow(10, scnFillAmount.Order));

            if (_isAnimated)
            {
                if (_coroutineAnimationBar != null)
                    StopCoroutine(_coroutineAnimationBar);

                _coroutineAnimationBar = StartCoroutine(AnimationProgressBar(fillAmount));
            }
            else
                _imgProgressBar.fillAmount = fillAmount;
        }

        public void ResetProgress()
        {
            _imgProgressBar.fillAmount = 1;

            if (_coroutineAnimationBar != null)
                StopCoroutine(_coroutineAnimationBar);
        }

        private IEnumerator AnimationProgressBar(float endValue)
        {
            float interval = (_imgProgressBar.fillAmount - endValue) / _timeAnimation;

            while (_imgProgressBar.fillAmount > endValue)
            {
                _imgProgressBar.fillAmount -= interval * Time.deltaTime;
                yield return null;
            }
        }
    }
}

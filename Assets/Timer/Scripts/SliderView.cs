using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
	public class SliderView : MonoBehaviour
	{
		[SerializeField] private Slider _slider;

		private IReadOnlyVariable<float> _currentValue;
		private IReadOnlyVariable<float> _maxValue;

		public void Initialize(IReadOnlyVariable<float> currentValue, IReadOnlyVariable<float> maxValue)
		{
			_currentValue = currentValue;
			_maxValue = maxValue;

			_currentValue.ValueChanged += OnCurrentChanged;

			UpdateValue(_currentValue.Value);
		}

		private void OnDestroy()
		{
			_currentValue.ValueChanged -= OnCurrentChanged;
		}

		private void OnCurrentChanged(float newValue) => UpdateValue(newValue);		

		private void UpdateValue(float value) => _slider.value = value/ _maxValue.Value;
	}
}
using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
	public class TimerHeartsView : MonoBehaviour
	{
		[SerializeField] private GameObject _heartSpritePrefab;
		[SerializeField] private Transform _parentForHearts;

		private IReadOnlyVariable<float> _currentValue;
		private IReadOnlyVariable<float> _maxValue;

		private Timer _timer;
		private List<GameObject> _hearts;

		public void Initialize(Timer timer, IReadOnlyVariable<float> currentValue, IReadOnlyVariable<float> maxValue)
		{
			_timer = timer;

			_currentValue = currentValue;
			_maxValue = maxValue;

			_currentValue.ValueChanged += OnCurrentChanged;
			_timer.Started += OnTimerStarted;
			_timer.Stoped += OnTimerStoped;

			_hearts = new List<GameObject>();
		}

		private void OnDestroy()
		{
			_currentValue.ValueChanged -= OnCurrentChanged;
			_timer.Started -= OnTimerStarted;
			_timer.Stoped -= OnTimerStoped;
		}

		private void OnTimerStarted() => CreateHearts();

		private void OnTimerStoped() => DestroyHearts();

		private void OnCurrentChanged(float value)
		{
			if (_hearts.Count - value >= 1)
				for (int i = 0; i < _hearts.Count; i++)
				{
					if (i == _hearts.Count - 1)
					{
						Destroy(_hearts[i]);
						_hearts.Remove(_hearts[i]);
					}
				}
		}

		private void CreateHearts()
		{
			for (int i = 0; i < (int)_maxValue.Value; i++)
			{
				GameObject heart = Instantiate(_heartSpritePrefab, _parentForHearts);
				_hearts.Add(heart);
			}
		}

		private void DestroyHearts()
		{
			for (int i = 0; i < _hearts.Count; i++)
				Destroy(_hearts[i]);

			_hearts.Clear();
		}
	}
}
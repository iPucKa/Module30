using System;
using System.Collections;
using UnityEngine;

namespace Timer
{
	public class Timer
	{		
		public event Action Started;
		public event Action Stoped;
		public event Action<bool> Paused;

		private MonoBehaviour _coroutineRunner;

		private ReactiveVariable<float> _remainingTime;
		private ReactiveVariable<float> _maxTime;

		private Coroutine _countDown;

		private bool _isPaused;

		public Timer(MonoBehaviour coroutineRunner, float remainingTime, float maxTime)
		{
			_coroutineRunner = coroutineRunner;
			_remainingTime = new ReactiveVariable<float>();
			_maxTime = new ReactiveVariable<float>(maxTime);

			_isPaused = false;
		}

		public IReadOnlyVariable<float> Max => _maxTime;

		public IReadOnlyVariable<float> Current => _remainingTime;

		public bool InProcess => _countDown != null;
		public bool IsPaused => _isPaused;

		public void Setup(float currentTime)
		{
			_remainingTime.Value = currentTime;
		}

		public void StartCountingTime()
		{
			if (_countDown != null)
				_coroutineRunner.StopCoroutine(_countDown);

			Started?.Invoke();

			_countDown = _coroutineRunner.StartCoroutine(Process());
		}

		public void StopCountineTime()
		{
			if (_countDown != null)
				_coroutineRunner.StopCoroutine(_countDown);

			Stoped?.Invoke();

			_countDown = null;
		}

		public void SetPause(bool isPaused)
		{
			Paused?.Invoke(isPaused);

			_isPaused = isPaused;
		}

		private IEnumerator Process()
		{
			while (_remainingTime.Value > 0)
			{
				_remainingTime.Value -= Time.deltaTime;

				_remainingTime.Value = Mathf.Clamp(_remainingTime.Value, 0, _maxTime.Value);

				yield return new WaitWhile(() => _isPaused);
			}

			_countDown = null;
			Stoped?.Invoke();
		}
	}
}

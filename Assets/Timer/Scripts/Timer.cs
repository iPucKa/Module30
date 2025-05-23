using System;
using System.Collections;
using UnityEngine;

public class Timer
{
	public event Action<float> ValueChanged;
	public event Action Started;
	public event Action Stoped;
	public event Action<bool> Paused;

	private MonoBehaviour _coroutineRunner;

	private float _remainingTime;
	private Coroutine _countDown;
	private float _maxTime;

	private bool _isPaused;

	public Timer(MonoBehaviour coroutineRunner, float maxTime)
	{
		_coroutineRunner = coroutineRunner;
		_maxTime = maxTime;
		_isPaused = false;
	}

	public float MaxTime => _maxTime;

	public bool InProcess => _countDown != null;
	public bool IsPaused => _isPaused;

	public void Setup(float currentTime)
	{
		_remainingTime = currentTime;

		ValueChanged?.Invoke(_remainingTime);
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
		while (_remainingTime > 0)
		{
			_remainingTime -= Time.deltaTime;

			ValueChanged?.Invoke(_remainingTime);

			if (_remainingTime < 0)
				_remainingTime = 0;

			yield return new WaitWhile(() => _isPaused);
		}

		_countDown = null;
		Stoped?.Invoke();
	}
}

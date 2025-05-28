using UnityEngine;

namespace Timer
{
	public class TimerHandler : MonoBehaviour
	{
		[SerializeField] private SliderView _sliderView;
		[SerializeField] private HeartsView _heartsView;
		[SerializeField] private UIView _uIView;

		[SerializeField] private float _maxTime;

		private Timer _timer;

		private void Awake()
		{
			_timer = new Timer(this, 0, _maxTime);

			_sliderView.Initialize(_timer.Current, _timer.Max);
			_heartsView.Initialize(_timer.Current, _timer.Max);
			
			_uIView.Initialize(_timer);
		}

		public void StartTimer()
		{
			if (_timer.InProcess == false)
			{
				_timer.SetPause(false);
				_timer.Setup(_maxTime);
				_timer.StartCountingTime();
			}

			else
			{
				_timer.StopCountineTime();
				_timer.Setup(0);
			}
		}

		public void PauseHandle()
		{
			if (_timer.InProcess)
			{
				if (_timer.IsPaused)
					_timer.SetPause(false);
				else
					_timer.SetPause(true);
			}
		}
	}
}
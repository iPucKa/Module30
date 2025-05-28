using System.Collections.Generic;
using UnityEngine;

namespace Timer
{
	public class HeartsView : MonoBehaviour
	{
		[SerializeField] private GameObject _heartSpritePrefab;
		[SerializeField] private Transform _parentForHearts;

		private const float Second = 1;

		private IReadOnlyVariable<float> _currentValue;
		private IReadOnlyVariable<float> _maxValue;

		private List<GameObject> _hearts;

		public void Initialize(IReadOnlyVariable<float> currentValue, IReadOnlyVariable<float> maxValue)
		{
			_currentValue = currentValue;
			_maxValue = maxValue;

			_currentValue.ValueChanged += OnCurrentChanged;

			_hearts = new List<GameObject>();
		}

		private void OnDestroy()
		{
			_currentValue.ValueChanged -= OnCurrentChanged;
		}

		private void OnCurrentChanged(float value)
		{
			if (value == 0)			
				DestroyHearts();			

			else if (value == _maxValue.Value)			
				CreateHearts();	

			else if (_hearts.Count - value >= Second)
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
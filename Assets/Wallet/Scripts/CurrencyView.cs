using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wallet
{
	public class CurrencyView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;
		[SerializeField] private Image _currencyImage;

		private ReactiveVariable<int> _value;

		public void Initialize(ReactiveVariable<int> value, Sprite currencySprite)
		{
			_value = value;
			_currencyImage.sprite = currencySprite;

			_value.ValueChanged += OnValueChanged;
		}

		private void OnDestroy()
		{
			_value.ValueChanged -= OnValueChanged;
		}

		private void OnValueChanged(int value)
		{
			_text.text = value.ToString();			
		}
	}
}


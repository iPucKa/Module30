using System;
using TMPro;

namespace Wallet
{
	public class CurrencyView : IDisposable
	{
		private TMP_Text _text;

		private ReactiveVariable<int> _value;

		public CurrencyView(ReactiveVariable<int> value, TMP_Text text)
		{
			_value = value;
			_text = text;
			
			_value.ValueChanged += OnValueChanged;
		}

		public void Dispose()
		{
			_value.ValueChanged -= OnValueChanged;
		}		

		private void OnValueChanged(int value)
		{
			_text.text = value.ToString();			
		}
	}
}


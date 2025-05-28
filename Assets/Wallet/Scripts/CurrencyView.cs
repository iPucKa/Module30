using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Wallet
{
	public class CurrencyView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;

		[SerializeField] private ItemsType _type;

		private IReadOnlyDictionary<ItemsType, ReactiveVariable<int>> _items;

		public void Initialize(IReadOnlyDictionary<ItemsType, ReactiveVariable<int>> items)
		{
			_items = items;

			_items[_type].ValueChanged += OnValueChanged;
		}

		private void OnDestroy()
		{
			_items[_type].ValueChanged -= OnValueChanged;
		}

		private void OnValueChanged(int value)
		{
			_text.text = value.ToString();
		}
	}
}


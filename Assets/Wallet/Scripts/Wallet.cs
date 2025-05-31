using System.Collections.Generic;
using UnityEngine;

namespace Wallet
{
	public class Wallet
	{
		private Dictionary<ItemsType, ReactiveVariable<int>> _items;

		private int _maxAmount;

		public Wallet(Dictionary<ItemsType, ReactiveVariable<int>> items, int maxAmount)
		{

			_maxAmount = maxAmount;
			_items = items;
		}

		public IEnumerable<ReactiveVariable<int>> Values => _items.Values;

		public void Add(ItemsType type, int valueToAdd)
		{
			if (_items.ContainsKey(type) == false)
				return;

			int newValue = Mathf.Clamp(_items[type].Value + valueToAdd, 0, _maxAmount);

			_items[type].Value = newValue;
		}

		public void Remove(ItemsType type, int valueToRemove)
		{
			if (_items.ContainsKey(type) == false)
				return;

			int newValue = Mathf.Clamp(_items[type].Value - valueToRemove, 0, _maxAmount);

			_items[type].Value = newValue;
		}
	}
}

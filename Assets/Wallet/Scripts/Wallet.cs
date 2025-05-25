using System.Collections.Generic;
using UnityEngine;

namespace Wallet
{
	public class Wallet
	{
		private ReactiveDictionary<ItemsType, int> _items;

		private int _maxAmount;

		public Wallet(Dictionary<ItemsType, int> items, int maxAmount)
		{
			_maxAmount = maxAmount;
			_items = new ReactiveDictionary<ItemsType, int>(items);			
		}
		
		public ReactiveDictionary<ItemsType, int> WalletItems => _items;

		public void Add(ItemsType type, int valueToAdd)
		{
			if (_items.Objects.ContainsKey(type) == false)
				return;	

			int newValue = Mathf.Clamp(_items.Objects[type] + valueToAdd, 0, _maxAmount);

			_items.Add(type, newValue);
		}

		public void Remove(ItemsType type, int valueToRemove)
		{
			if (_items.Objects.ContainsKey(type) == false)
				return;

			int newValue = Mathf.Clamp(_items.Objects[type] - valueToRemove, 0, _maxAmount);

			_items.Remove(type, newValue);
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
	private ReactiveVariable<ItemsType, int> _currentAmount;
	private ReactiveVariable<ItemsType, int> _maxAmount;

	private Dictionary<ItemsType, int> _items;

	public Wallet(Dictionary<ItemsType, int> items, int currentAmount, int maxAmount)
	{
		_currentAmount = new ReactiveVariable<ItemsType, int>(currentAmount);
		_maxAmount = new ReactiveVariable<ItemsType, int>(maxAmount);
		
		_items = items;
	}

	public ReactiveVariable<ItemsType, int> CurrentAmount => _currentAmount;

	public void Add(ItemsType type, int valueToAdd)
	{
		if (_items.ContainsKey(type) == false)
			return;

		_currentAmount.SetValue(type, Mathf.Clamp(_items[type] + valueToAdd, 0, _maxAmount.Value));
		
		_items[type] = _currentAmount.Value;
	}

	public void Remove(ItemsType type, int valueToRemove)
	{
		if (_items.ContainsKey(type) == false)
			return;

		_currentAmount.SetValue(type, Mathf.Clamp(_items[type] - valueToRemove, 0, _maxAmount.Value));

		_items[type] = _currentAmount.Value;
	}
}

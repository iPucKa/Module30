using System;
using System.Collections.Generic;

namespace Wallet
{
	public class ReactiveDictionary<TKey, TValue> where TValue : IEquatable<TValue>
	{
		public event Action<TKey, TValue> ValueChanged;

		private Dictionary<TKey, TValue> _items = new();

		public ReactiveDictionary(Dictionary<TKey, TValue> items)
		{
			_items = items;
		}

		public IReadOnlyDictionary<TKey, TValue> Objects => _items;		

		public void Add(TKey key, TValue value)
		{
			_items[key] = value;
			ValueChanged?.Invoke(key, value);
		}

		public void Remove(TKey key, TValue value)
		{
			_items[key] = value;
			ValueChanged?.Invoke(key, value);
		}		
	}
}

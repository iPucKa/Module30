using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
	public class Inventory
	{
		private Dictionary<int, Item> _inventoryItems;

		private int _maxSize;

		public Inventory(Dictionary<int, Item> inventoryItems, int maxSize)
		{
			_inventoryItems = inventoryItems;
			_maxSize = maxSize;
		}

		public int CurrentSize => _inventoryItems.Sum(id => id.Value.Count);

		public void Update(float deltaTime)
		{
			foreach (KeyValuePair<int, Item> item in _inventoryItems)
			{
				if (item.Value.Count == 0)
				{
					_inventoryItems.Remove(item.Key);
					break;
				}
			}
		}

		public void Add(Item item)
		{
			if (CurrentSize + item.Count > _maxSize)
				return;

			int id = item.ID;

			if (_inventoryItems.ContainsKey(id) == false)
			{
				_inventoryItems.Add(id, item);
				return;
			}

			Item itemInInventory = _inventoryItems[id];

			int newCount = itemInInventory.Count + item.Count;

			itemInInventory.SetCount(newCount);
		}


		public Item GetItemsBy(int id, int count)
		{
			foreach (KeyValuePair<int, Item> item in _inventoryItems)
			{
				if (item.Key == id)
				{
					Item itemInInventory = _inventoryItems[id];
					Item removedItem = _inventoryItems[id];

					if (count > itemInInventory.Count)
					{
						Debug.Log("В инвентаре недостаточно предметов");
						return null;
					}

					int newCount = itemInInventory.Count - count;

					itemInInventory.SetCount(newCount);
					removedItem.SetCount(count);

					return removedItem;
				}
			}

			return null;
		}

		public int GetItemCountBy(int id)
		{
			if (_inventoryItems.ContainsKey(id))
				return _inventoryItems[id].Count;

			return default(int);
		}		
	}
}

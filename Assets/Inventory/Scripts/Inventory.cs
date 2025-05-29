using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
	public class Inventory
	{
		private Dictionary<Item, int> _inventoryItems;

		private int _maxSize;

		public Inventory(Dictionary<Item, int> inventoryItems, int maxSize)
		{
			_inventoryItems = inventoryItems;
			_maxSize = maxSize;
		}

		public int CurrentSize => _inventoryItems.Sum(item => item.Value);

		public void Update(float deltaTime)
		{
			foreach (KeyValuePair<Item, int> item in _inventoryItems)
			{
				if (item.Value == 0)
				{
					_inventoryItems.Remove(item.Key);
					break;
				}
			}
		}

		public void Add(Item item, int valueToAdd)
		{
			if (CurrentSize + _inventoryItems[item] > _maxSize)
				return;

			if (_inventoryItems.ContainsKey(item) == false)
			{
				_inventoryItems.Add(item, valueToAdd);
				return;
			}

			_inventoryItems[item] += valueToAdd;	
		}


		public Item GetItemsBy(int id, int count, out int removeItemCount)
		{
			removeItemCount = 0;

			foreach (KeyValuePair<Item, int> item in _inventoryItems)
			{
				if (item.Key.ID == id)
				{					
					if (count > _inventoryItems[item.Key])
					{
						Debug.Log("В инвентаре недостаточно предметов");
						removeItemCount = 0;
						return null;
					}

					_inventoryItems[item.Key] -= count;

					removeItemCount = count;
					return item.Key;
				}
			}

			return null;
		}

		public int GetCountBy(int id)
		{
			foreach (KeyValuePair<Item, int> item in _inventoryItems)
			
				if (item.Key.ID == id)				
					return _inventoryItems[item.Key];					

			return default(int);
		}		
	}
}

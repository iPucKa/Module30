namespace Inventory
{
	public class Item
	{
		public Item(int id, int count)
		{
			ID = id;
			Count = count;
		}

		public int ID { get; private set; }

		public int Count { get; private set; }

		public void SetCount(int value) => Count = value;
	}
}


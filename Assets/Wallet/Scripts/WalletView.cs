using TMPro;
using UnityEngine;

namespace Wallet
{
	public class WalletView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _coinsCountText;
		[SerializeField] private TMP_Text _diamondsCountText;
		[SerializeField] private TMP_Text _energieCountText;

		private ReactiveDictionary<ItemsType, int> _items;

		public void Initialize(ReactiveDictionary<ItemsType, int> items)
		{
			_items = items;
			_items.ValueChanged += OnValueChanged;
		}

		private void OnDestroy()
		{
			_items.ValueChanged -= OnValueChanged;
		}

		private void OnValueChanged(ItemsType type, int value)
		{
			switch (type)
			{
				case ItemsType.Coins:
					UpdateValue(_coinsCountText, value);
					break;
				case ItemsType.Diamonds:
					UpdateValue(_diamondsCountText, value);
					break;
				case ItemsType.Energie:
					UpdateValue(_energieCountText, value);
					break;
				default:
					break;
			}
		}

		private void UpdateValue(TMP_Text text, int value) => text.text = value.ToString();		
	}
}
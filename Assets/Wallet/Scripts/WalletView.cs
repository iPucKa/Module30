using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
	[SerializeField] private TMP_Text _coinsCountText;
	[SerializeField] private TMP_Text _diamondsCountText;
	[SerializeField] private TMP_Text _energieCountText;

	private ReactiveVariable<ItemsType, int> _currentAmount;

	public void Initialize(ReactiveVariable<ItemsType,int> currentAmount)
	{
		_currentAmount = currentAmount;

		_currentAmount.Changed += OnValueChanged;
	}	

	private void OnDestroy()
	{
		_currentAmount.Changed -= OnValueChanged;
	}	

	private void OnValueChanged(ItemsType type, int value)
	{
		if(type == ItemsType.Coins)
			UpdateValue(_coinsCountText, value);

		if (type == ItemsType.Diamonds)
			UpdateValue(_diamondsCountText, value);

		if (type == ItemsType.Energie)
			UpdateValue(_energieCountText, value);
	}

	private void UpdateValue(TMP_Text text, int value)
	{
		text.text = value.ToString();
	}
}

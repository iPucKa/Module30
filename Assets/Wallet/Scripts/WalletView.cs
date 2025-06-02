using System.Collections.Generic;
using UnityEngine;

namespace Wallet
{
	public class WalletView : MonoBehaviour
	{
		[SerializeField] private CurrencyView _currencyViewPrefab;
		[SerializeField] private Transform _spawnPlace;

		[SerializeField] private List<Sprite> _currencySprites;

		private Wallet _wallet;

		public void Initialize(Wallet wallet)
		{
			_wallet = wallet;

			CreateCurrencyView();
		}

		private void CreateCurrencyView()
		{
			int index = 0;

			foreach (ReactiveVariable<int> value in _wallet.Values)
			{
				CurrencyView currencyView = Instantiate(_currencyViewPrefab, _spawnPlace, false);
				currencyView.Initialize(value, _currencySprites[index]);

				index++;
			}
		}
	}
}
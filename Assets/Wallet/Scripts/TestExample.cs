using System.Collections.Generic;
using UnityEngine;

namespace Wallet
{
	public class TestExample : MonoBehaviour
	{
		[SerializeField] private WalletView _walletView;
		[SerializeField] private List<CurrencyView> _currencyViews;

		private const int MaxAmount = 100;

		private Wallet _wallet;
		private Dictionary<ItemsType, ReactiveVariable<int>> _items;

		private void Awake()
		{
			_items = new Dictionary<ItemsType, ReactiveVariable<int>>()
			{
				{ItemsType.Coins, new ReactiveVariable<int>(0)},
				{ItemsType.Diamonds, new ReactiveVariable<int>(0)},
				{ItemsType.Energie, new ReactiveVariable<int>(0)},
			};

			_wallet = new Wallet(_items, MaxAmount);

			//_walletView.Initialize(_wallet.WalletItems);
			
			foreach (CurrencyView view in _currencyViews)
				view.Initialize(_wallet.Items);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
				_wallet.Add(ItemsType.Coins, 15);

			if (Input.GetKeyDown(KeyCode.Alpha2))
				_wallet.Remove(ItemsType.Coins, 3);

			if (Input.GetKeyDown(KeyCode.Alpha3))
				_wallet.Add(ItemsType.Diamonds, 10);

			if (Input.GetKeyDown(KeyCode.Alpha4))
				_wallet.Remove(ItemsType.Diamonds, 2);

			if (Input.GetKeyDown(KeyCode.Alpha5))
				_wallet.Add(ItemsType.Energie, 5);

			if (Input.GetKeyDown(KeyCode.Alpha6))
				_wallet.Remove(ItemsType.Energie, 1);
		}

		public void ShowWallet() => _walletView.gameObject.SetActive(true);

		public void CloseWallet() => _walletView.gameObject.SetActive(false);
	}
}
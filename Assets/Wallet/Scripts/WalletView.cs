using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Wallet
{
	public class WalletView : MonoBehaviour
	{
		[SerializeField] private List<TMP_Text> _texts;

		private Wallet _wallet;
		private CurrencyView _view;

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
				_view = new(value, _texts[index]);
				index++;
			}
		}

		private void OnDestroy()
		{
			_view.Dispose();
		}
	}
}
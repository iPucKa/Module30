using System;

namespace Wallet
{
	public interface IReadOnlyVariable<TValue>
	{
		event Action<TValue> ValueChanged;

		TValue Value { get; }
	}
}

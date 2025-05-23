using System;
public class ReactiveVariable<TKey, TValue> where TValue : IEquatable<TValue>
{
    public event Action<TKey, TValue> Changed;

	private TValue _value;

    public ReactiveVariable()
    {
        _value = default(TValue);
    }

    public ReactiveVariable(TValue value)
    {
        _value = value;
    }

	public TValue Value => _value;    

    public void SetValue(TKey key, TValue value)
    {
		TValue oldValue = _value;

		_value = value;

		if (_value.Equals(oldValue) == false)
			Changed?.Invoke(key, _value);
	}
}

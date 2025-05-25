using UnityEngine;

public class Enemy : MonoBehaviour, IGridObject
{
	private ISettable _settings;
	private bool _isBinded;

	public void Initialize(ISettable settings)
	{
		_settings = settings;
	}	

	public float Strength => _settings.Strength;
	public float Agility => _settings.Agility;
	public float Health => _settings.Health;
	public bool IsBinded => _isBinded;

	public void BindTo(Vector3 worldPosition)
	{
		transform.position = worldPosition;
		_isBinded = true;
	}
}

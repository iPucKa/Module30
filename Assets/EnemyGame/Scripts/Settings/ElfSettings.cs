using System;
using UnityEngine;

[Serializable]
public class ElfSettings : ISettable
{
	[SerializeField] private float _strength;
	[SerializeField] private float _agility;
	[SerializeField] private float _health;

	public float Strength => _strength;
	public float Agility => _agility;
	public float Health => _health;
}

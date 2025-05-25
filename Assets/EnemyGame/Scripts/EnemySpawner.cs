using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Ork _orkPrefab;
	[SerializeField] private Elf _elfPrefab;
	[SerializeField] private Dragon _dragonPrefab;

	[SerializeField] private OrkSettings[] _orkSettings;
	[SerializeField] private ElfSettings[] _elfSettings;
	[SerializeField] private DragonSettings[] _dragonSettings;

	private const int MaxEnemies = 3;
	private int _spawnRange = 5;

	private List<Enemy> _enemies = new List<Enemy>();
	private Grid _grid;

	private void Awake()
	{
		if(_spawnRange < MaxEnemies - 1)
			_spawnRange = MaxEnemies - 1;

		_grid = new Grid();

		CreateEnemy();
		InitializeEnemy();
		SetPosition();
	}

	private void CreateEnemy()
	{
		for (int i = 0; i < MaxEnemies; i++)
		{
			Enemy ork = Instantiate(_orkPrefab, transform);
			Enemy elf = Instantiate(_elfPrefab, transform);
			Enemy dragon = Instantiate(_dragonPrefab, transform);

			_enemies.Add(ork);
			_enemies.Add(elf);
			_enemies.Add(dragon);
		}
	}

	private void InitializeEnemy()
	{
		foreach (Enemy enemy in _enemies)
		{
			switch (enemy)
			{
				case Ork ork:
					enemy.Initialize(_orkSettings[GetRandomIndex(_orkSettings.Length)]);
					break;
				case Elf elf:
					enemy.Initialize(_elfSettings[GetRandomIndex(_elfSettings.Length)]);
					break;
				case Dragon dragon:
					enemy.Initialize(_dragonSettings[GetRandomIndex(_dragonSettings.Length)]);
					break;
				default:
					break;
			}

			Debug.Log($"{enemy.name}. Сила = {enemy.Strength}, ловкость = {enemy.Agility}, здоровье = {enemy.Health}");
		}
	}

	private int GetRandomIndex(int maxCount)
	{
		return Random.Range(0, maxCount);
	}

	private void SetPosition()
	{
		foreach (Enemy enemy in _enemies)
		{
			while(enemy.IsBinded == false)
			{
				int xPosition = Random.Range(0, _spawnRange);
				int zPosition = Random.Range(0, _spawnRange);

				Vector2Int coordinate = new Vector2Int(xPosition, zPosition);

				if (enemy.IsBinded == false)
					_grid.Bind(enemy, coordinate);
			}
		}
	}
}

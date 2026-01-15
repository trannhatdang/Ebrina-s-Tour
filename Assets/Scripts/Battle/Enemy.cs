using UnityEngine;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
	[SerializeField] bool _isMoving = false;
	[SerializeField] GameObject _enemy;
	[SerializeField] int _hp = 100;
	[SerializeField] EnemySpawner _spawner;

	private Rigidbody2D _rb;
	private Pathfinder _pathfinder;
	void Start()
	{
		_pathfinder = GetComponent<Pathfinder>();
		_rb = GetComponent<Rigidbody2D>();
	}

	void Initialize(GameObject enemy)
	{
		_enemy = enemy;
	}

	void Update()
	{
		if(_hp <= 0)
		{
			_spawner.Die(this.gameObject);
			_hp = 100;
		}

		_rb.MovePosition(_rb.position + _pathfinder.AStar(_enemy.transform.position));
	}

	public void SetSpawner(EnemySpawner spawner)
	{
		if(spawner) return;

		_spawner = spawner;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("PlayerHitbox"))
		{
			_hp -= 1; //what is player attack?
		}
	}
}

using UnityEngine;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
	[SerializeField] int _hp = 100;
	[SerializeField] bool _isMoving = false;
	[SerializeField] GameObject _enemy;
	[SerializeField] EnemySpawner _spawner;
	[SerializeField] Animator _animator; 

	private Rigidbody2D _rb;
	private Pathfinder _pathfinder;
	void Start()
	{
		_pathfinder = GetComponent<Pathfinder>();
		_rb = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	public void Initialize(GameObject enemy, EnemySpawner spawner)
	{
		_enemy = enemy;
		_spawner = spawner;
	}

	void FixedUpdate()
	{
		if(_hp <= 0)
		{
			_spawner.Die(this.gameObject);
			_hp = 100;
		}

		if(_isMoving)
		{
			_rb.MovePosition(_rb.position + _pathfinder.AStar(_enemy.transform.position) * Time.fixedDeltaTime);
			StartMoving();
		}
	}

	public void StartMoving()
	{
		_animator.SetBool("Moving", true);
	}

	public void StopMoving()
	{
		_animator.SetBool("Moving", false);
	}

	public void SetSpawner(EnemySpawner spawner)
	{
		if(spawner) return;

		_spawner = spawner;
	}

	public void SetEnemy(GameObject enemy)
	{
		if(enemy) return;

		_enemy = enemy;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("PlayerHitbox"))
		{
			_hp -= 1; //what is player attack?
		}
	}
}

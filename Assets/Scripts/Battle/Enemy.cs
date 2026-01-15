using UnityEngine;
public class Enemy : MonoBehaviour
{
	[SerializeField] bool _isMoving = false;
	[SerializeField] List<GameObject> _enemies;
	[SerializeField] int _hp = 100;
	[SerializeField] EnemySpawner _spawner;

	private Rigidbody2D _rb;
	private Pathfinder _pathfinder;
	void Start()
	{
		_pathfinder = GetComponent<Pathfinder>();
		_rb = GetComponent<Rigidbody2D>();
	}

	void Initialize(List<GameObject> enemies)
	{
		_enemies = new List<GameObject>(enemies);
	}

	void Update()
	{
		if(_hp <= 0)
		{
			spawner.Die(this.gameObject);
			_hp = 100;
		}

		_rb.MovePosition(_rb.position + _pathfinder.AStar());
	}

	void SetSpawner(EnemySpawner spawner)
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

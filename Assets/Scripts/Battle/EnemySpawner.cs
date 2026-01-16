using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] GameObject _enemyPrefab;
	[SerializeField] GameObject _player;
	private ObjectPool<GameObject> pool;
	[SerializeField] private float _timer = 100;

	void Awake()
	{
		if(!_enemyPrefab || !_enemyPrefab.GetComponent<Enemy>())
		{
			Debug.LogError("Enemy Prefab assigned to spawner is invalid!");
			Destroy(this.gameObject);
		}

		pool = new ObjectPool<GameObject>(
				createFunc: CreateEnemy,
				actionOnGet: OnGet,
				actionOnRelease: OnRelease,
				actionOnDestroy: OnDestroyItem,
				collectionCheck: true,
				defaultCapacity: 10,
				maxSize: 20
		);
	}

	void FixedUpdate()
	{
		if(_timer <= 0)
		{
			Spawn();
			_timer = 2;
		}
		else
		{
			_timer -= 0.02f;
		}
	}

	private GameObject CreateEnemy()
	{
		GameObject gameObject = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
		gameObject.name = "PooledEnemy";
		gameObject.SetActive(false);

		Enemy enemy = gameObject.GetComponent<Enemy>();
		enemy.Initialize(_player, this);
		//enemy.SetSpawner(this);
		//enemy.SetEnemy(_player);

		return gameObject;
	}

	private void OnGet(GameObject gameObject)
	{
		gameObject.SetActive(true);
	}

	private void OnRelease(GameObject gameObject)
	{
		gameObject.SetActive(false);
	}

	private void OnDestroyItem(GameObject gameObject)
	{
		Destroy(gameObject);
	}

	public void Spawn()
	{
		GameObject obj = pool.Get();
		obj.transform.position = transform.position;
	}

	public void Die(GameObject obj)
	{
		pool.Release(obj);
	}
}

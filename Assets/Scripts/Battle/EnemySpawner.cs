using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] GameObject _enemyPrefab;
	private ObjectPool<GameObject> pool;

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

	private GameObject CreateEnemy()
	{
		GameObject gameObject = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform.gameObject);
		gameObject.name = "PooledEnemy";
		gameObject.SetActive(false);
		gameObject.GetComponent<Enemy>().SetSpawner(this);

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

using UnityEngine;
public class Enemy : MonoBehaviour
{
	[SerializeField] bool _isMoving = false;
	[SerializeField] List<GameObject> _enemies;
	private Rigidbody2D _rb;
	private Pathfinder _pathfinder;
	void Start()
	{
		//_currNode = _tree.InitNode();
		_pathfinder = GetComponent<Pathfinder>();
	}

	void Initialize(List<GameObject> enemies)
	{
		_enemies = new List<GameObject>(enemies);
	}

	void Update()
	{

	}
}

using UnityEngine;
using System.Collections.Generic;

public class Parallax : MonoBehaviour
{
	[SerializeField] List<GameObject> _buildings;
	[SerializeField] MovingCamera _movingCamera;
	[SerializeField] float _baseSpeed = .2f;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(!_movingCamera || !_movingCamera.isMoving)
		{
			return;
		}

		for(int i = 0; i < _buildings.Count(); ++i)
		{
			var building = _buildings[i];
			Vector2 velocity = _movingCamera.moveLeft ? Vector2.left : Vector2.right;
			velocity *= ((i + 1) * _baseSpeed);

			building.transform.position = building.transform.position + velocity * Time.fixedDeltaTime;
		}
	}
}

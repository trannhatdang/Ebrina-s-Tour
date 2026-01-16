using UnityEngine;

public class MovingCamera : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] Player _player;
	int _moveSpeed = 2;

	public bool isMoving {get; private set;} = false;
	public bool moveLeft {get; private set;} = false;

	void Start()
	{
		if(_player) 
		{
			_moveSpeed = _player.HortSpeed;
		}
		else
		{
			Debug.LogError("No Player assigned for Camera!");
		}
	}

	public void Move(bool isLeft)
	{
		isMoving = true;
		moveLeft = isLeft;
		//Debug.Log("hi");
	}

	public void Stop()
	{
		isMoving = false;
	}

	void FixedUpdate()
	{
		if(!isMoving) return;

		Vector3 velocity = Vector3.zero;
		if(moveLeft)
		{
			velocity = Vector2.left * _moveSpeed;
		}
		else
		{
			velocity = Vector2.right * _moveSpeed;
		}

		transform.position = transform.position + velocity * Time.fixedDeltaTime;
	}
}

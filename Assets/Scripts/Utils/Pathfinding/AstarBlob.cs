using UnityEngine;

public class AstarBlob : MonoBehaviour
{
	public bool _isColliding { get; private set; } = false;
	public bool _collidingPlayer { get; private set; } = false;
	void OnCollisionEnter2D(Collision2D other)
	{
		_isColliding = true;

		if(other.gameObject.CompareTag("Player"))
		{
			_collidingPlayer = true;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{ 
		_isColliding = false;
		_collidingPlayer = false;
	}
}

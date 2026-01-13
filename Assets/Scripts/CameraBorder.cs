using UnityEngine;

public class CameraBorder : MonoBehaviour
{
	MovingCamera _movingCamera;
	[SerializeField] bool _isLeft = false;
	void Start()
	{
		_movingCamera = transform.parent.GetComponent<MovingCamera>();
	}

	void OnCollision2DEnter(Collision2D other)
	{
		if(!_movingCamera || !other.gameObject.CompareTag("Player"))
		{
			return;
		}

		_movingCamera.Move(_isLeft);
	}

	void OnCollision2DExit(Collision2D other)
	{
		if(!_movingCamera)
		{
			return;
		}

		_movingCamera.Stop();
	}
}

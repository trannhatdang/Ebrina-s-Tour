using UnityEngine;

public class CameraBorder : MonoBehaviour
{
	[SerializeField] MovingCamera _movingCamera;
	[SerializeField] bool _isLeft = false;
	void Start()
	{
		_movingCamera = transform.parent.GetComponent<MovingCamera>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(!_movingCamera || !other.gameObject.CompareTag("Player"))
		{
			return;
		}
		Debug.Log("hi");

		_movingCamera.Move(_isLeft);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(!_movingCamera)
		{
			return;
		}

		_movingCamera.Stop();
	}
}

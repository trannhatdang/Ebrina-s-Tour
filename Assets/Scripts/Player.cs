using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] float _hortSpeed = 2f;
	[SerializeField] float _vertSpeed = 1f;

	float _hort;
	float _vert;

	Rigidbody2D _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		_rb.MovePosition(_rb.position + new Vector2(_hort * _hortSpeed, _vert * _vertSpeed) * Time.fixedDeltaTime);
	}

	public void Move(InputAction.CallbackContext context)
	{
		_hort = context.ReadValue<Vector2>().x;
		_vert = context.ReadValue<Vector2>().y;
	}
}

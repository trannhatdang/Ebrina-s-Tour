using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public int HortSpeed { get; private set; } = 2;
	public int VertSpeed { get; private set; } = 1;

	Vector2 _velocity;
	bool _canAttack = true;
	bool _isLeft = false;

	Rigidbody2D _rb;
	Animator _anim;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(_velocity.sqrMagnitude > 0)
		{
			_anim.SetBool("Moving", true);
		}
		else
		{
			_anim.SetBool("Moving", false);
		}

		Vector3 _currentEuler = transform.eulerAngles;
		if(_velocity.x > 0 && _isLeft)
		{
			transform.Rotate(0, 180, 0);
			_isLeft = false;
		}
		else if(_velocity.x < 0 && !_isLeft)
		{
			transform.Rotate(0, 180, 0);
			_isLeft = true;
		}
		_rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
	}

	public void Move(InputAction.CallbackContext context)
	{
		float hort = context.ReadValue<Vector2>().x * HortSpeed;
		float vert = context.ReadValue<Vector2>().y * VertSpeed;

		_velocity = new Vector2(hort, vert);
	}

	public void Attack(InputAction.CallbackContext context)
	{
		if(!_canAttack) return;

		_anim.SetTrigger("Attack");
		_canAttack = false;
	}

//dashing, how?
	public void Dash(InputAction.CallbackContext context)
	{
		_dashing = true;
	}

	public void SetAttack()
	{
		_canAttack = true;
	}
}

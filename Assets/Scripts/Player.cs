using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField] float _hortSpeed = 2f;
	[SerializeField] float _vertSpeed = 1f;

	Vector2 _velocity;
	bool _canAttack = true;

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

		_rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
	}

	public void Move(InputAction.CallbackContext context)
	{
		float hort = context.ReadValue<Vector2>().x * _hortSpeed;
		float vert = context.ReadValue<Vector2>().y * _vertSpeed;

		_velocity = new Vector2(hort, vert);
	}

	public void Attack(InputAction.CallbackContext context)
	{
		if(!_canAttack) return;

		_anim.SetTrigger("Attack");
		_canAttack = false;
	}

	public void SetAttack()
	{
		_canAttack = true;
	}
}

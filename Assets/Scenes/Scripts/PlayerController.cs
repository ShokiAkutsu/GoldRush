using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Player�̈ړ��X�s�[�h")]
	[SerializeField] float _moveSpeed = 5f;

	/// <summary>���������̓��͒l</summary>
	float _horizontal;

	Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		_horizontal = Input.GetAxis("Horizontal"); // �����L�[ or A/D
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_moveSpeed * _horizontal, _rb.velocity.y);
	}
}

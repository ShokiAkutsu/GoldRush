using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float _moveSpeed = 5f;

	/// <summary>水平方向の入力値</summary>
	float _horizontal;

	/// <summary>水平方向の入力値</summary>
	Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		_horizontal = Input.GetAxis("Horizontal"); // ←→キー or A/D
	}

	private void FixedUpdate()
	{
		_rb.AddForce(Vector2.right * _horizontal * _moveSpeed, ForceMode2D.Force);
	}
}

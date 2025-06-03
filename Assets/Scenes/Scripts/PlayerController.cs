using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Player�̈ړ��X�s�[�h")]
	[SerializeField] float _moveSpeed = 5f;
	[Header("Player�̓���ɕ\������Coin")]
	[SerializeField] GameObject _coinPrefab;
	[Header("Player������W")]
	[SerializeField] Transform _headPos;

	//�l������Coin�̊i�[List
	List<GameObject> _playerCoins;
	float _coinDistance = 0.5f;

	/// <summary>���������̓��͒l</summary>
	float _horizontal;

	/// <summary>���������̓��͒l</summary>
	Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_playerCoins = new List<GameObject>();
	}

	void Update()
	{
		_horizontal = Input.GetAxis("Horizontal"); // �����L�[ or A/D
	}

	private void FixedUpdate()
	{
		_rb.AddForce(Vector2.right * _horizontal * _moveSpeed, ForceMode2D.Force);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Coin")
		{
			GameObject coin = Instantiate(_coinPrefab);
			coin.transform.SetParent(_headPos, false);
			coin.transform.localPosition = new Vector3(0, _playerCoins.Count * _coinDistance, 0); // �e��̈ʒu

			_playerCoins.Add(coin);
		}
	}
}

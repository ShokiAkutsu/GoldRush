using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Playerの移動スピード")]
	[SerializeField] float _moveSpeed = 5f;
	[Header("Playerの頭上に表示するCoin")]
	[SerializeField] GameObject _coinPrefab;
	[Header("Player頭上座標")]
	[SerializeField] Transform _headPos;

	//獲得したCoinの格納List
	List<GameObject> _playerCoins;
	float _coinDistance = 0.5f;

	/// <summary>水平方向の入力値</summary>
	float _horizontal;

	/// <summary>水平方向の入力値</summary>
	Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_playerCoins = new List<GameObject>();
	}

	void Update()
	{
		_horizontal = Input.GetAxis("Horizontal"); // ←→キー or A/D
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
			coin.transform.localPosition = new Vector3(0, _playerCoins.Count * _coinDistance, 0); // 親基準の位置

			_playerCoins.Add(coin);
		}
	}
}

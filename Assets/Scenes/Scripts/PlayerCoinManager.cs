using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCoinManager : MonoBehaviour
{
    [Header("試用のために使う(所持金)")]
    [SerializeField] int _coin = 0;
	public int Coin => _coin;

	[Header("Playerの頭上に表示するCoin")]
	[SerializeField] GameObject _coinPrefab;
	[Header("Player頭上座標")]
	[SerializeField] Transform _headPos;

	//獲得したCoinの積み上げ用
	List<GameObject> _playerCoins;
	//CoinとCoinの間隔
	float _coinDistance = 0.5f;

	[SerializeField] CoinUnit _coinUnit;

    // Start is called before the first frame update
    void Start()
    {
		_playerCoins = new List<GameObject>();
	}

    // Update is called once per frame
    void Update()
    {
        
	}

	//引数の数値分のCoinを持っているか
	public bool SpindCoin(int Cost)
	{
		//差し引きできないなら即終わり
		if(_coin < Cost)
		{
			return false;
		}

		_coin -= Cost;
		CoinInstantiate();

		return true;
	}

	private void CoinInstantiate()
	{
		//表示しているコインを全てDestoryで初期化(後で表示/非表示にして負荷を減らしたい)
		//積み上げるだけならこの処理がいらないのは重々承知
		foreach (GameObject Coin in _playerCoins) 
		{
			Destroy(Coin);
		}
		_playerCoins.Clear();

		int remainder = _coin;

		//所持金数値に応じて切り替わるようにしたい(妥協案：UIとして数字を出しておく)
		for (int i = _coinUnit.Parameter.Count - 1; 0 <= i; i--)
		{
			int coinSum = remainder / _coinUnit.Parameter[i].Unit; //まとめられたコインが何枚必要か
			remainder %= _coinUnit.Parameter[i].Unit;       //残高を余りで格納

			if (coinSum == 0) continue;

			for (int makeCoin = 0; makeCoin < coinSum; makeCoin++)
			{
				GameObject coin = Instantiate(_coinUnit.Parameter[i].CoinPrefab);
				coin.transform.SetParent(_headPos, false);
				coin.transform.localPosition = new Vector3(0, _playerCoins.Count * _coinDistance, 0); // 親基準の位置
				
				_playerCoins.Add(coin);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Coin")
		{
			_coin++;

			CoinInstantiate();

			/*
			//以下、１まいずつ出すやつ
			GameObject coin = Instantiate(_coinPrefab);
			coin.transform.SetParent(_headPos, false);
			coin.transform.localPosition = new Vector3(0, _playerCoins.Count * _coinDistance, 0); // 親基準の位置

			_playerCoins.Add(coin);
			*/
		}
	}
}

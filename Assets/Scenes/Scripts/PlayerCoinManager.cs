using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCoinManager : MonoBehaviour
{
    [Header("���p�̂��߂Ɏg��(������)")]
    [SerializeField] int _coin = 0;
	public int Coin => _coin;

	[Header("Player�̓���ɕ\������Coin")]
	[SerializeField] GameObject _coinPrefab;
	[Header("Player������W")]
	[SerializeField] Transform _headPos;

	//�l������Coin�̐ςݏグ�p
	List<GameObject> _playerCoins;
	//Coin��Coin�̊Ԋu
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

	//�����̐��l����Coin�������Ă��邩
	public bool SpindCoin(int Cost)
	{
		//���������ł��Ȃ��Ȃ瑦�I���
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
		//�\�����Ă���R�C����S��Destory�ŏ�����(��ŕ\��/��\���ɂ��ĕ��ׂ����炵����)
		//�ςݏグ�邾���Ȃ炱�̏���������Ȃ��̂͏d�X���m
		foreach (GameObject Coin in _playerCoins) 
		{
			Destroy(Coin);
		}
		_playerCoins.Clear();

		int remainder = _coin;

		//���������l�ɉ����Đ؂�ւ��悤�ɂ�����(�Ë��āFUI�Ƃ��Đ������o���Ă���)
		for (int i = _coinUnit.Parameter.Count - 1; 0 <= i; i--)
		{
			int coinSum = remainder / _coinUnit.Parameter[i].Unit; //�܂Ƃ߂�ꂽ�R�C���������K�v��
			remainder %= _coinUnit.Parameter[i].Unit;       //�c����]��Ŋi�[

			if (coinSum == 0) continue;

			for (int makeCoin = 0; makeCoin < coinSum; makeCoin++)
			{
				GameObject coin = Instantiate(_coinUnit.Parameter[i].CoinPrefab);
				coin.transform.SetParent(_headPos, false);
				coin.transform.localPosition = new Vector3(0, _playerCoins.Count * _coinDistance, 0); // �e��̈ʒu
				
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
			//�ȉ��A�P�܂����o�����
			GameObject coin = Instantiate(_coinPrefab);
			coin.transform.SetParent(_headPos, false);
			coin.transform.localPosition = new Vector3(0, _playerCoins.Count * _coinDistance, 0); // �e��̈ʒu

			_playerCoins.Add(coin);
			*/
		}
	}
}

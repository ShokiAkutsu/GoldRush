using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CoinUnit : ScriptableObject
{
	[Header("�ŏ��P�ʂ���")]
	[SerializeField] List<CoinParameter> _coinParameters = new List<CoinParameter>();
	public List<CoinParameter> Parameter => _coinParameters;

	[Serializable]
	public class CoinParameter
    {
		[SerializeField] GameObject _coinPrefab;
		[Header("�����̒P��")]
		[SerializeField] int _unit;

		public GameObject CoinPrefab => _coinPrefab;
		public int Unit => _unit;
	}
}

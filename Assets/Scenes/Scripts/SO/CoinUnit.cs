using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CoinUnit : ScriptableObject
{
	[Header("最小単位から")]
	[SerializeField] List<CoinParameter> _coinParameters = new List<CoinParameter>();
	public List<CoinParameter> Parameter => _coinParameters;

	[Serializable]
	public class CoinParameter
    {
		[SerializeField] GameObject _coinPrefab;
		[Header("お金の単位")]
		[SerializeField] int _unit;

		public GameObject CoinPrefab => _coinPrefab;
		public int Unit => _unit;
	}
}

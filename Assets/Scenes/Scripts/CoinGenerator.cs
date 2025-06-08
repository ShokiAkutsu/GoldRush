using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
	[Header("CoinPrefab���i�[")]
	[SerializeField] GameObject _coinPrefab;
	[Header("Prefab�����p�x")]
	[SerializeField] float _interval = 3f;
    [Header("Prefab�̔����͈�(�}X���W ��Βl)")]
    [SerializeField] float _posLimitX = 10f;

    float _timer;
	LaboratoryScript _laboratory;

	void Start()
	{
		//��s�ɕς���\��
		_laboratory = GameObject.Find("Laboratory").GetComponent<LaboratoryScript>();
		_interval = _laboratory.GetEffectParameter();
	}

	void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _interval)
        {
			_timer = 0;
            GameObject Coin = Instantiate(_coinPrefab);
			float posX = Random.Range(-(_posLimitX), _posLimitX);
            Coin.transform.position = new Vector3(posX, 10, 0);
        }
    }

	public void LevelUpSet()
	{
		_interval = _laboratory.GetEffectParameter();
	}
}

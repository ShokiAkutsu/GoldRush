using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
	[Header("CoinPrefab‚ðŠi”[")]
	[SerializeField] GameObject _coinPrefab;
	[Header("Prefab¶¬•p“x")]
	[SerializeField] float _interval = 1f;
    [Header("Prefab‚Ì”­¶”ÍˆÍ(}XÀ•W â‘Î’l)")]
    [SerializeField] float _posLimitX = 10f;
    float _timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryScript : MonoBehaviour
{
    [SerializeField] Building _buildingSO;
    PlayerCoinManager _playerCoinManager;
	CoinGenerator _coinGenerator;

    [SerializeField] int _lv = 0;
	bool _isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerCoinManager = GameObject.Find("Player").GetComponent<PlayerCoinManager>();
		_coinGenerator = GameObject.Find("Generator").GetComponent<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.I) && _isTrigger)
		{
			if (_buildingSO.buildStatus.Count - 1 == _lv)
			{
				Debug.Log("‚±‚êˆÈã”­“W‚Å‚«‚Ü‚¹‚ñ");
			}
			//Š‹à‚ª•K—v”ï—pˆÈã‚Á‚Ä‚¢‚é‚È‚ç”­“W
			else if (_playerCoinManager.SpindCoin(_buildingSO.buildStatus[_lv].Cost))
			{
				_lv++;
				Debug.Log($"{_buildingSO.buildStatus[_lv].Name}‚É”­“W‚µ‚Ü‚µ‚½");
				_coinGenerator.LevelUpSet();
			}
			//–¢–‚È‚ç”­“W‚Å‚«‚È‚¢(ƒeƒLƒXƒg‚ğ“ü‚ê‚é‚©”Û‚©)
			else
			{
				Debug.Log("”­“W‚Å‚«‚Ü‚¹‚ñ");
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        if(collision.tag == "Player") _isTrigger = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player") _isTrigger = false;
	}

	public float GetEffectParameter()
	{
		return _buildingSO.buildStatus[_lv].EffectParameter;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag =="Player")
        {
            Debug.Log("Žæ‚ê‚Ü‚µ‚½");
            Destroy(this.gameObject);
        }
	}
}

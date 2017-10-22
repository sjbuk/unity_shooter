using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            int score = other.GetComponent<enemy>().points;
            MainGameController.instance.AdjustScore(score);
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum  StartOrStop {Start = 1 ,Stop = 0};

public class waveCollider : MonoBehaviour {

	public StartOrStop TriggerType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider colObject){
		if (colObject.CompareTag ("Player")) {
			if (TriggerType == StartOrStop.Start)
				SendMessageUpwards ("StartWave");
			else
				SendMessageUpwards ("StopWave");
		}
	}
}

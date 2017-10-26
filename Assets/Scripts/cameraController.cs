using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
    private float _scrollSpeed ;
	// Use this for initialization
	void Start () {
        _scrollSpeed = MainGameController.instance.scrollSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * _scrollSpeed * Time.deltaTime);
		
	}
}

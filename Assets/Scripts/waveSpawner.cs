using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


public class waveSpawner : MonoBehaviour {

	public Spawner[] spawners;

	List<GameObject> enemyList;
	bool spawnStarted;
	
	// Use this for initialization
	void Start () {
		spawnStarted = false;
		enemyList = new List<GameObject>();
		Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	void StartWave (){
		if (!spawnStarted) {
			spawnStarted = true;
			foreach (Spawner spawner in spawners) {
				StartCoroutine ("SpawnEnemy",spawner);
			}
		}
	}

	void StopWave (){
		StopCoroutine ("SpawnEnemy");
		foreach (GameObject enemy in enemyList) {
			Destroy (enemy);
		}
	}

	//Coroutine SpawnEnemy
	IEnumerator SpawnEnemy(Spawner spawner){
		GameObject enemy;
			for (int i = 0; i < spawner.spawnCount; i++) {
				enemy = Instantiate (spawner.spawnGameObject);
				enemy.GetComponent<SplineFollower> ().followSpeed = spawner.speed;
				enemy.GetComponent<SplineFollower> ().autoFollow = true;
				enemyList.Add (enemy);
				yield return new WaitForSeconds (spawner.spawnDelay);
			}
		yield return null;
	}
}

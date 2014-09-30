using UnityEngine;
using System.Collections;

public class newSpawner : MonoBehaviour {

	public GameObject defaultRock;
	public Vector3 spawnLocation;
	public Quaternion spawnRotation;

	public float spawnTimer;
	public float spawnTimerMaster = 2;

	void Awake(){
		Spawn ();
	}

	void Spawn(){
		spawnLocation = new Vector3 (Random.Range (-8, 8), 10, 0);
		spawnRotation = new Quaternion(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360),0);
		Instantiate(defaultRock, spawnLocation, spawnRotation);
		if (spawnTimerMaster >= .5) {
			spawnTimerMaster -= spawnTimer;
				}
		Invoke ("Spawn", spawnTimerMaster);
	}
}

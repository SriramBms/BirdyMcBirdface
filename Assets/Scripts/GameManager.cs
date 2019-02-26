using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public Transform enemy;

	public List<Transform> spawnPoints = new List<Transform>();

	private const float timeToSpawn = 1f;
	private float timeSinceSpawn = timeToSpawn/2;

	// Use this for initialization
	void Start () {

		//these are empty game objects that are children of the GameManager object
		//this gives us points in the scene to use as spawn points
		spawnPoints.Add (transform.Find ("Spawn1"));
		spawnPoints.Add (transform.Find ("Spawn2"));
		spawnPoints.Add (transform.Find ("Spawn3"));
	}
	
	// Update is called once per frame
	void Update () {
	
		//keep track of how much time has past since the last frame
		timeSinceSpawn += Time.deltaTime;

		//if enough time as passed, spawn a new enemy
		if (timeSinceSpawn > timeToSpawn) {
			timeSinceSpawn = 0f;
			SpawnEnemy();
		}

	}

	void SpawnEnemy(){

		//pick a random spawn point from the three
		Transform spawnPoint = spawnPoints [Random.Range (0, spawnPoints.Count)];

		//make a new enemy and place it at the spawn point
		Transform newEnemy = Transform.Instantiate (enemy);
		newEnemy.position = spawnPoint.position;

	}
}

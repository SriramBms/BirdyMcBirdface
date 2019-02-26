using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {
    public Transform[] clouds;
    public List<Transform> spawnPoints = new List<Transform>();
    private const float timeToSpawn = 5f;
    private float timeSinceSpawn = timeToSpawn / 2;
    // Use this for initialization
    void Start () {
        spawnPoints.Add(transform.Find("CloudSpawn1"));
        spawnPoints.Add(transform.Find("CloudSpawn2"));
        spawnPoints.Add(transform.Find("CloudSpawn3"));
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceSpawn += Time.deltaTime;
        
        if (timeSinceSpawn > timeToSpawn)
        {
            timeSinceSpawn = 0f;
            SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        int num = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[num];
        Transform newCLoud = Transform.Instantiate(clouds[Random.Range(0, clouds.Length)]);
        if (0 == num)
        {
            CloudBehavior cb = newCLoud.GetComponent<CloudBehavior>();
            cb.SetSpeed(1f);
            cb.SetSortingLayer("backgroundClouds");
        }
        newCLoud.position = spawnPoint.position;

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawnScript : MonoBehaviour {
    public Transform[] trees;
    public Transform spawnPoint;
    private float timeToSpawn;
    //private const float timeToSpawn = 5f;
    private float timeSinceSpawn = 2f;
    // Use this for initialization
    void Start () {
        timeToSpawn = (float)Random.Range(0, 5);
        spawnPoint = transform.Find("TreeSpawn1");
       
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn > timeToSpawn)
        {
            timeToSpawn = (float)Random.Range(0, 5); 
            timeSinceSpawn = 0f;
            SpawnTree();
        }
    }

    private void SpawnTree()
    {
        Transform newTree = Transform.Instantiate(trees[Random.Range(0, trees.Length)]);
        newTree.position = spawnPoint.position;
    }



}

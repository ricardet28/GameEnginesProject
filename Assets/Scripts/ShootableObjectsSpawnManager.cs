using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectsSpawnManager : MonoBehaviour {

    [SerializeField]
    private Transform[] spawns;
    private float currentTime;
    private int timeToSpawn;

    public Rigidbody[] objects;
    public int maxTimeSpawn;
    public int minTimeSpawn;
    public float objectSpawnForce;
    
    
    

    void Start () {

        spawns = new Transform[this.transform.childCount];
        for (int i = 0; i < spawns.Length; i++)
        {
            spawns[i] = this.transform.GetChild(i);
        }

	}
	
    void Spawn()
    {
        int objectIndex = Random.Range(0, objects.Length);
        int spawnIndex = Random.Range(0, spawns.Length);
        Rigidbody objectSpawned = (Rigidbody)Instantiate(objects[objectIndex], spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        objectSpawned.velocity = spawns[spawnIndex].transform.right * objectSpawnForce;
    }
	
	void Update () {

        currentTime += Time.deltaTime;
        if (currentTime >= timeToSpawn)
        {
            Spawn();
            currentTime = 0f;
            timeToSpawn = Random.Range(minTimeSpawn, maxTimeSpawn + 1);
        }
        

	}
}

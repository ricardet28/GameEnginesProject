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
    public float objectSpawnVelocity;
    
    
    

    void Start () {
        timeToSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);
        spawns = new Transform[this.transform.childCount];
        for (int i = 0; i < spawns.Length; i++)
        {
            spawns[i] = this.transform.GetChild(i);
        }

	}
	
    void Spawn()
    {
        Debug.Log("spawn");
        int objectIndex = Random.Range(0, objects.Length);
        int spawnIndex = Random.Range(0, spawns.Length);
        GameObject objectSpawned = Instantiate(objects[objectIndex].gameObject, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        //Rigidbody objectSpawned = (Rigidbody)Instantiate(objects[objectIndex], spawns[spawnIndex].position, spawns[spawnIndex].rotation);

        if (objectSpawned.GetComponent<Diamond>() != null)
        {
            objectSpawned.GetComponent<Diamond>().MoveBullet(spawns[spawnIndex].right, objectSpawnVelocity);
        }
        else if (objectSpawned.GetComponent<Rubi>() != null)
        {
            objectSpawned.GetComponent<Rubi>().MoveBullet(spawns[spawnIndex].right, objectSpawnVelocity);
        }
        else if (objectSpawned.GetComponent<Esmerald>() != null)
        {
            objectSpawned.GetComponent<Esmerald>().MoveBullet(spawns[spawnIndex].right, objectSpawnVelocity);
        }


        currentTime = 0f;
        timeToSpawn = Random.Range(minTimeSpawn, maxTimeSpawn + 1);

    }
	
	void Update () {

        currentTime += Time.deltaTime;
        if (currentTime >= timeToSpawn)
        {
            Spawn();
            //currentTime = 0f;
            
        }
        

	}
}

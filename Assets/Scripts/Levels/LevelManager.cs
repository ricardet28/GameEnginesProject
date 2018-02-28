using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int neededPoints;
    public float maxTimeToComplete;
    /*[HideInInspector]*/public bool levelCompleted;
    public Vector3 spawnPoint;

    private bool doorOpened;
    private int currentPoints;
    private float currentTime;
    
    private void Awake()
    {
        levelCompleted = false;
        doorOpened = false;
        currentPoints = 0;
        currentTime = 0f;
    }

    private void Update()
    {
        
    }

    private bool OpenDoor()
    {
        return currentPoints >= neededPoints && currentTime < maxTimeToComplete;
    }

}

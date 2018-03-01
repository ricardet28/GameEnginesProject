﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int neededPoints;
    public float maxTimeToComplete;
    /*[HideInInspector]*/public bool levelCompleted;
    public Vector3 spawnPoint;

    [SerializeField]
    private int currentPoints;
    private float currentTime;
    
    private void Awake()
    {
        levelCompleted = false;
        currentPoints = 0;
        currentTime = 0f;
    }

    private void Update()
    {
        
    }

    public bool CheckLevelCompleted()
    {
        if (currentPoints >= neededPoints && currentTime < maxTimeToComplete)
        {
            levelCompleted = true;
        }
        return levelCompleted;
        
    }

    public void AddPoints(int p)
    {
        currentPoints += p;
    }
}

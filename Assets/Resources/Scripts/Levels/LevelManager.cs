using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int neededPoints;
    public float maxTimeToComplete;
    /*[HideInInspector]*/public bool levelCompleted;
    public Transform spawnPoint;

    [SerializeField]
    private int currentPoints;
    private float currentTime;

    private void Awake()
    {
        levelCompleted = false;
        currentPoints = 0;
        currentTime = 0f;
    }

    private void Start()
    {
        GameManager.instance._currentLevel = this;
        //this can be changed.
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;
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

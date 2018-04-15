using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelManager : MonoBehaviour {

    public int neededPoints;
    public float maxTimeToComplete;
    /*[HideInInspector]*/public bool levelCompleted;
    public Transform spawnPoint;
    public Text UITime;
    public Text UIPoints;

    [SerializeField]
    private int currentPoints;
    private float currentTime;

    private void Awake()
    {
        levelCompleted = false;
        currentPoints = 0;
        currentTime = 0f;

        UITime = GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
        UIPoints = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();

    }

    private void Start()
    {
        GameManager.instance._currentLevel = this;
        //this can be changed.
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;

        UIPoints.text = currentPoints.ToString();
        UITime.text = currentTime.ToString();
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
        UIPoints.text = currentPoints.ToString();

        
    }
}

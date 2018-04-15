using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class LevelManager : MonoBehaviour {


    /*[HideInInspector]*/public bool levelCompleted;
    public Transform spawnPoint;
    

    [SerializeField]

    int neededPoints;

    private int currentPoints;
    private float currentTime;

    private void Awake()
    {
        levelCompleted = false;
    }

    private void Start()
    {
        GameManager.instance._currentLevel = this;
        //this can be changed.
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;

        SetInitialParameters();

        GameManager.instance.UIPoints.text = "POINTS: " + currentPoints.ToString();
        GameManager.instance.UITime.text = currentTime.ToString();
    }

    private void SetInitialParameters()
    {
        GameManager.instance.UIPoints.enabled = true;
        GameManager.instance.UITime.enabled = true;

        GameManager.Scenes activeScene = GameManager.instance.activeScene;

        switch (activeScene)
        {           
            case GameManager.Scenes.Tutorial0:
                neededPoints = (int)GameManager.PointsToPassLevel.Tutorial0;
                currentTime = (int)GameManager.MaxTimeToCompleteLevel.Tutorial0;
                break;
            case GameManager.Scenes.Tutorial1:
                neededPoints = (int)GameManager.PointsToPassLevel.Tutorial1;
                currentTime = (int)GameManager.MaxTimeToCompleteLevel.Tutorial1;
                break;
        }
    }

    public bool CheckLevelCompleted()
    {
        if (currentPoints >= neededPoints && currentTime > 0)
        {
            levelCompleted = true;
            
        }

        GameManager.instance.UIPoints.enabled = false;
        GameManager.instance.UITime.enabled = false;
        return true;

        //return levelCompleted;       
    }

    public void AddPoints(int p)
    {
        currentPoints += p;
        GameManager.instance.UIPoints.text = "POINTS: " + currentPoints.ToString();      
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        GameManager.instance.UITime.text = ((int)currentTime).ToString();
    }
}

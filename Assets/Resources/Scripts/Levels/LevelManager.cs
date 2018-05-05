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

        UIManager.instance.UIPoints.text = "POINTS: " + currentPoints.ToString();
        UIManager.instance.UITime.text = currentTime.ToString();
    }

    private void SetInitialParameters()
    {
        UIManager.instance.UIPoints.enabled = true;
        UIManager.instance.UITime.enabled = true;

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
            GameManager.instance.scenesState[SceneManager.GetActiveScene().buildIndex+1] = true;
            UIManager.instance.UIPoints.enabled = false;
            UIManager.instance.UITime.enabled = false;

        }

        return levelCompleted;       
    }

    public void AddPoints(int p)
    {
        Debug.Log(currentPoints);
        currentPoints += p;
        UIManager.instance.UIPoints.text = "POINTS: " + currentPoints.ToString();      
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        UIManager.instance.UITime.text = ((int)currentTime).ToString();

        if(currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

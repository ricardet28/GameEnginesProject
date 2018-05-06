using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class LevelManager : MonoBehaviour {

    /*[HideInInspector]*/public bool levelCompleted;
    public Transform spawnPoint;
    [SerializeField] int neededPoints;
    private int currentPoints;
    private float currentTime;
    private int playerHealthPoints;

    private PlayerHealth _playerHealth;
    private WeaponManager _weaponManager;

    private void Awake()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        levelCompleted = false;
    }

    private void Start()
    {
        GameManager.instance._currentLevel = this;
        //this can be changed.
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;
        playerHealthPoints = _playerHealth.healthPoints;
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
        //Debug.Log(currentPoints);
        currentPoints += p;
        UIManager.instance.UIPoints.text = "POINTS: " + currentPoints.ToString();      
    }

    private void handleTimeLeft()
    {
        currentTime -= Time.deltaTime;
        UIManager.instance.UITime.text = ((int)currentTime).ToString();

        if (currentTime <= 0)
        {
            reloadThisScene();
        }
    }

    private bool checkPlayerAlive()
    {
        playerHealthPoints = _playerHealth.healthPoints;
        UIManager.instance.UIHealth.text = playerHealthPoints.ToString();
        return playerHealthPoints > 0 ? true : false;
    }

    private void handlePlayerDead()
    {
        if (!checkPlayerAlive())
        {
            reloadThisScene();
        }
    }

    private void reloadThisScene()
    {
        _playerHealth.resetHealthPoints();
        _weaponManager.restartBullets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        handlePlayerDead();
        handleTimeLeft();
    }
}

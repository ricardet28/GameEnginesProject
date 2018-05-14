using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public bool levelCompleted;
    public Transform spawnPoint;
    [SerializeField] int neededPoints;
    public float maxTimeToComplete;
    private int currentPoints;
    public float currentTime;
    private int playerHealthPoints;
    private bool playerDead = false;
    //private bool levelCompleted = false;

    private GameObject _player;
    private PlayerHealth _playerHealth;
    private WeaponManager _weaponManager;
    private FirstPersonController _firstPersonController;
    public float startDelay = 3f;
    public float endDelay = 3f;

    public static LevelManager instance = null;

    private void Awake()
    {
        instance = this;
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _firstPersonController = _player.GetComponent<FirstPersonController>();
        _weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        _player.transform.position = spawnPoint.position;
        _player.transform.rotation = spawnPoint.rotation;
        levelCompleted = false;
    }

    private void Start()
    {
        Debug.Log("LevelManager creado!");
        GameManager.instance._currentLevel = this;
        playerHealthPoints = _playerHealth.initHealthPoints;
        SetInitialParameters();
        UIManager.instance.UIPoints.enabled = true;
        UIManager.instance.UIPointsToReach.enabled = true;
        UIManager.instance.UITime.enabled = true;
        UIManager.instance.healthBar.gameObject.SetActive(true);
        UIManager.instance.fillImage.color = UIManager.instance.fullHealth;
        UIManager.instance.healthBar.value = playerHealthPoints;
        UIManager.instance.initHealthPoints = playerHealthPoints;
        UIManager.instance.healthPoints = playerHealthPoints;
        UIManager.instance.UIHealth.text = playerHealthPoints.ToString();
        UIManager.instance.UIPoints.text = "POINTS: " + currentPoints.ToString();
        UIManager.instance.UIPointsToReach.text = "/ " + neededPoints;
        UIManager.instance.UITime.text = currentTime.ToString();
        Color _newColor = UIManager.instance.UIDamageImage.color;
        _newColor.a = 0;
        UIManager.instance.UIDamageImage.color = _newColor;
        UIManager.instance.InfoImage.enabled = true;
        UIManager.instance.InfoText.enabled = true;
        UIManager.instance.SubInfoText.enabled = true;

        StartCoroutine(LevelStarting());
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
            case GameManager.Scenes.Tutorial2:
                neededPoints = (int)GameManager.PointsToPassLevel.Tutorial2;
                currentTime = (int)GameManager.MaxTimeToCompleteLevel.Tutorial2;
                break;
        }

        maxTimeToComplete = currentTime;
    }

    public bool CheckLevelCompleted()
    {
        if (currentPoints >= neededPoints && currentTime > 0)
        {
            Debug.Log("Nivel completado! ");
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

    private bool checkPlayerAlive()
    {
        Debug.Log("Player tiene " + playerHealthPoints + " puntos de salud! ");
        playerHealthPoints = _playerHealth.healthPoints;
        UIManager.instance.healthPoints = playerHealthPoints;
        UIManager.instance.UIHealth.text = playerHealthPoints.ToString();
        return playerHealthPoints > 0 ? true : false;
    }
    
    public void DisablePlayerControls()
    {
        _firstPersonController.enabled = false;
        _playerHealth.enabled = false;
        _weaponManager.enabled = false;
        _player.GetComponent<Collider>().enabled = false;
    }

    public void EnablePlayerControls()
    {
        _firstPersonController.enabled = true;
        _playerHealth.enabled = true;
        _weaponManager.enabled = true;
        _player.GetComponent<Collider>().enabled = true;
    }

    private IEnumerator LevelStarting()
    {
        DisablePlayerControls();
        AIManager.instance.DisableAI();
        UIManager.instance.InfoText.text = "LEVEL STARTING";
        float _currentTime = 0f;
        while (_currentTime <= startDelay)
        {
            _currentTime += Time.deltaTime;
            int timeLeft = (int)startDelay - (int)_currentTime;
            UIManager.instance.SubInfoText.text = timeLeft.ToString();
            yield return null;
        }  
        EnablePlayerControls();
        AIManager.instance.EnableAI();
        UIManager.instance.InfoImage.enabled = false;
        UIManager.instance.InfoText.enabled = false;
        UIManager.instance.SubInfoText.enabled = false;
        StartCoroutine(HandleTimeLeft());
        StartCoroutine(HandlePlayerDead());
    }

    private IEnumerator HandleTimeLeft()
    {
        while (currentTime > 0)
        {
            if (!playerDead && !levelCompleted)//don't keep resting time if player is dead.
            {
                currentTime -= Time.deltaTime;
                UIManager.instance.UITime.text = ((int)currentTime).ToString();
            }
            yield return null;

        }
        yield return StartCoroutine(TimeExceeded());
        reloadThisScene();
    }

    private IEnumerator HandlePlayerDead()
    {
        while (checkPlayerAlive())
        {
            yield return null;
        }
        playerDead = true;
        yield return StartCoroutine(PlayerDead());
        reloadThisScene();
    }

    private void reloadThisScene()
    {
        _playerHealth.resetHealthPoints();
        _weaponManager.restartBullets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator TimeExceeded()
    {
        UIManager.instance.InfoImage.enabled = true;
        UIManager.instance.InfoText.enabled = true;
        UIManager.instance.SubInfoText.enabled = true;
        UIManager.instance.InfoText.text = "TIME EXCEEDED";
        DisablePlayerControls();
        AIManager.instance.DisableAI();
        Debug.Log("TIEMPO AGOTADO. ");
        float _currentTime = 0f;
        while (_currentTime <= startDelay)
        {
            _currentTime += Time.deltaTime;
            int timeLeft = (int)startDelay - (int)_currentTime;
            UIManager.instance.SubInfoText.text = timeLeft.ToString();
            yield return null;
        }
    }

    private IEnumerator PlayerDead()
    {
        UIManager.instance.InfoImage.enabled = true;
        UIManager.instance.InfoText.enabled = true;
        UIManager.instance.SubInfoText.enabled = true;
        UIManager.instance.InfoText.text = "YOU DIED";
        DisablePlayerControls();
        AIManager.instance.DisableAI();
        Debug.Log("PLAYER MUERTO. ");
        
        float _currentTime = 0f;
        while (_currentTime <= startDelay)
        {
            _currentTime += Time.deltaTime;
            int timeLeft = (int)startDelay - (int)_currentTime;
            UIManager.instance.SubInfoText.text = timeLeft.ToString();
            yield return null;
        }
    }

}

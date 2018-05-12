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
    private int currentPoints;
    private float currentTime;
    private int playerHealthPoints;

    private GameObject _player;
    private PlayerHealth _playerHealth;
    private WeaponManager _weaponManager;
    private FirstPersonController _firstPersonController;
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    public float startDelay = 3f;
    public float endDelay = 3f;

    private void Awake()
    {
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

        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);

        playerHealthPoints = _playerHealth.healthPoints;
        SetInitialParameters();       
        UIManager.instance.fillImage.color = UIManager.instance.fullHealth;
        UIManager.instance.healthBar.value = playerHealthPoints;
        UIManager.instance.initHealthPoints = playerHealthPoints;
        UIManager.instance.healthPoints = playerHealthPoints;
        UIManager.instance.UIPoints.text = "POINTS: " + currentPoints.ToString();
        UIManager.instance.UIPointsToReach.text = "/ " + neededPoints;
        UIManager.instance.UITime.text = currentTime.ToString();
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
        playerHealthPoints = _playerHealth.healthPoints;
        UIManager.instance.healthPoints = playerHealthPoints;
        UIManager.instance.UIHealth.text = playerHealthPoints.ToString();
        return playerHealthPoints > 0 ? true : false;
    }
    
    private void DisablePlayerControls()
    {
        _firstPersonController.enabled = false;
        _playerHealth.enabled = false;
        _weaponManager.enabled = false;
    }

    private void EnablePlayerControls()
    {
        _firstPersonController.enabled = true;
        _playerHealth.enabled = true;
        _weaponManager.enabled = true;
    }

    private IEnumerator LevelStarting()
    {
        //DISABLE CONTROLS
        DisablePlayerControls();
        //DISABLE AI
        //MOSTRAR UN TEXTO POR PANTALLA DICIENDO NIVEL 1 EMPEZAMOS!
        yield return startWait;
        EnablePlayerControls();
        StartCoroutine(HandleTimeLeft());
        StartCoroutine(HandlePlayerDead());
    }

    private IEnumerator HandleTimeLeft()
    {
        Debug.Log("HandleTimeLeft enabled!");
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UIManager.instance.UITime.text = ((int)currentTime).ToString();
            yield return null;
        }
        yield return StartCoroutine(TimeExceeded());
        reloadThisScene();
    }

    private IEnumerator HandlePlayerDead()
    {
        Debug.Log("HandlePlayerDead enabled!");
        while (checkPlayerAlive())
        {
            yield return null;
        }

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
        //MOSTRAR UN TEXTO POR PANTALLA DICIENDO SE HA AGOTADO EL TIEMPO!!
        //DISABLE CONTROLS
        //STOP TIME
        //DISABLE AI
        Debug.Log("TIEMPO AGOTADO. ");
        yield return endWait;
    }

    private IEnumerator PlayerDead()
    {
        //MOSTRAR UN TEXTO POR PANTALLA DICIENDO QUE HA MUERTO EL PLAYER!!
        //DISABLE CONTROLS
        //STOP TIME
        //STOP AI
        Debug.Log("PLAYER MUERTO. ");
        yield return endWait;
    }

}

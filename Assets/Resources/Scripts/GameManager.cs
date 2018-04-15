using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public enum Scenes { Loader = 0, Menu = 1, Corridor = 2, Tutorial0 = 3, Tutorial1 = 4 };
    public enum PointsToPassLevel { Loader = 0, Menu = 0, Corridos = 0, Tutorial0 = 100, Tutorial1= 200};
    public enum MaxTimeToCompleteLevel { Loader = 0, Menu = 0, Corridos = 0, Tutorial0 = 40, Tutorial1 = 40};

    public static GameManager instance = null;
    public LevelManager _currentLevel;

    public Text UITime;
    public Text UIPoints;

    public bool[] scenesState;
    
    public Scenes activeScene;

    //private int firstSceneToLoad = 2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
        SceneManager.LoadScene((int)Scenes.Corridor);
    }

    private void Start()
    {
        InitArrayScenes();
        UITime = GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
        UIPoints = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();

        UITime.enabled = false;
        UIPoints.enabled = false;

    }

    private bool LevelCompleted()
    {
        return _currentLevel.levelCompleted;
    }

    private void SetCurrentLevelManager()
    {
        _currentLevel = GameObject.FindObjectOfType<LevelManager>();
    }

    public void ChangeLevel(Scenes scene)
    {
        activeScene = scene;
        SceneManager.LoadScene((int)scene);
    }

    private void InitArrayScenes()
    {
        scenesState = new bool[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < scenesState.Length; i++)
        {
            scenesState[i] = false;
        }

        scenesState[(int)Scenes.Tutorial0] = true;
        activeScene = Scenes.Corridor;
    }
}

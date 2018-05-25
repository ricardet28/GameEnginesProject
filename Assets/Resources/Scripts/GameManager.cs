using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public enum Scenes { Loader = 0, Menu = 1, Corridor = 2, Tutorial0 = 3, Tutorial1 = 4, Tutorial2 = 5 };
    public enum PointsToPassLevel { Loader = 0, Menu = 0, Corridos = 0, Tutorial0 = 400, Tutorial1= 400, Tutorial2 = 400};
    public enum MaxTimeToCompleteLevel { Loader = 0, Menu = 0, Corridos = 0, Tutorial0 = 40, Tutorial1 = 60, Tutorial2 = 60};
    

    public static GameManager instance = null;
    public LevelManager _currentLevel;

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
        scenesState = new bool[SceneManager.sceneCountInBuildSettings + 1];
        for (int i = 0; i < scenesState.Length; i++)
        {
            scenesState[i] = false;
        }

        scenesState[(int)Scenes.Tutorial0] = true;
        scenesState[(int)Scenes.Tutorial1] = true;
        scenesState[(int)Scenes.Tutorial2] = true;
       
        scenesState[(int)Scenes.Corridor] = true;
        activeScene = Scenes.Corridor;

    }
}

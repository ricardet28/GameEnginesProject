using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public enum Scenes { Loader = 0, Menu = 1, Corridor = 2, Tutorial0 = 3, Tutorial1 = 4 };

    public static GameManager instance = null;
    public bool[] scenesState;
    public LevelManager _currentLevel;

    private int firstSceneToLoad = 2;

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
        SetCurrentLevelManager();
        InitArrayScenes();
    }

    private void Update()
    {
        SetCurrentLevelManager();
    }

    private bool LevelCompleted()
    {
        return _currentLevel.levelCompleted;
    }

    private void SetCurrentLevelManager()
    {
        _currentLevel = GameObject.FindObjectOfType<LevelManager>();
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
        //wait for scene loaded and then:
        SetCurrentLevelManager();
    }

    private void InitArrayScenes()
    {
        scenesState = new bool[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < scenesState.Length; i++)
        {
            scenesState[i] = false;
        }
        scenesState[(int)Scenes.Tutorial0] = true;

    }

   
}

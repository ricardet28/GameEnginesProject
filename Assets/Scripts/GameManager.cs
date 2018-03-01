using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool[] scenesState;

    public LevelManager _currentLevel;

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
        
        SceneManager.LoadScene(3);

    }

    private void Start()
    {
        SetCurrentLevelManager();
        InitArrayScenes();
    }

    private void Update()
    {
        //SetCurrentLevelManager();
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
        SetCurrentLevelManager();
    }

    private void InitArrayScenes()
    {
        scenesState = new bool[SceneManager.sceneCount];
        for (int i = 0; i < scenesState.Length; i++)
        {
            scenesState[i] = false;
        }
    }

   
}
